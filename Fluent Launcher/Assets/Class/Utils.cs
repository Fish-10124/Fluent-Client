using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Resources.Icons;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using MinecraftLaunch.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Launcher.Assets.Class
{
    class Utils
    {

        // 如果需要获取版本类型，可以使用返回值的parameter属性
        public static SettingsCardTagDescriptionInfos InstanceEntryToTagInfos(MinecraftEntry instance)
        {
            List<string> descriptions = [instance.Version.VersionId, instance.Version.Type.ToString()];
            BitmapImage headerIcon;
            InstanceType type;

            if (instance.IsVanilla)
            {
                // 原版 Minecraft 图标和类型
                headerIcon = GetVanillaIcon(instance.Version.Type);
                type = InstanceType.Normal;
            }
            else
            {
                // 模组 Minecraft 图标和类型
                var modInstance = instance as ModifiedMinecraftEntry ?? throw new Exception("Instance parse failed!");
                IList<ModLoaderInfo> modLoaders = modInstance.ModLoaders.ToList();

                foreach (var modLoader in modLoaders)
                {
                    descriptions.Add($"{modLoader.Type} {modLoader.Version}");
                }

                headerIcon = GetModLoaderIcon(modLoaders.First().Type);
                type = InstanceType.Modified;
            }

            return new SettingsCardTagDescriptionInfos()
            {
                Header = instance.Id,
                Description = descriptions,
                HeaderIcon = headerIcon,
                parameter = type
            };

        }

        // 获取原版 Minecraft 图标
        public static BitmapImage GetVanillaIcon(MinecraftVersionType type) =>
                type switch
                {
                    MinecraftVersionType.Release => Icons.Grass_Block,
                    MinecraftVersionType.PreRelease => Icons.Crafting_Table,
                    MinecraftVersionType.Snapshot => Icons.Crafting_Table,
                    MinecraftVersionType.OldBeta => Icons.Dirt_Path,
                    MinecraftVersionType.OldAlpha => Icons.Dirt_Path,
                    MinecraftVersionType.Unknown => Icons.Furnace,
                    _ => throw new NotImplementedException()
                };

        // 获取模组加载器图标
        public static BitmapImage GetModLoaderIcon(ModLoaderType type) =>
            type switch
            {
                ModLoaderType.Any => Icons.Furnace,
                ModLoaderType.Forge => Icons.Forge_Icon,
                ModLoaderType.Cauldron => Icons.Furnace,
                ModLoaderType.LiteLoader => Icons.LiteLoader_Icon,
                ModLoaderType.Fabric => Icons.Fabric_Icon,
                ModLoaderType.Quilt => Icons.Quilt_Icon,
                ModLoaderType.NeoForge => Icons.NeoForge_Icon,
                ModLoaderType.OptiFine => Icons.OptiFine_Icon,
                ModLoaderType.Unknown => Icons.Furnace,
                _ => throw new NotImplementedException()
            };

       // 读取实例的ini配置文件
        public static InstanceOptions ReadInstanceOptions(IniFile iniFile)
        {
            List<string?> options = [
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.InstanceDescription),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.Independent),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.WindowTitle),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.CustomInfomation),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.GameJava),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.MemoryRadio),
                iniFile.Read(InstanceOptions.IniSection, InstanceOptions.Keys.MemoryCustomize)
            ];

            // 局部函数：解析可空整数值
            int? ParseNullableInt(string? input) =>
                input != null && int.TryParse(input, out var result) ? result : null;
            bool? ParseNullableBool(string? input) =>
                input != null && bool.TryParse(input, out var result) ? result : null;

            return new()
            {
                InstanceDescription = options[0],
                Independency = ParseNullableBool(options[1]) ?? true,
                WindowTitle = options[2],
                CustomInfomation = options[3],
                GameJava = ParseNullableInt(options[4]) ?? 0,
                MemoryRadio = ParseNullableInt(options[5]) ?? 0,
                MemoryCustomize = ParseNullableInt(options[6]) ?? 3 * 1024
            };
        }
    }

    public class IniFile
    {
        public string FilePath { get; }

        public IniFile(string filePath)
        {
            this.FilePath = filePath;
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string? defaultValue, StringBuilder returnValue, int size, string filePath);

        public void Write(string section, string key, string value)
        {
            _ = WritePrivateProfileString(section, key, value, FilePath);
        }

        public string? Read(string section, string key)
        {
            var returnValue = new StringBuilder(255);
            int length = GetPrivateProfileString(section, key, null, returnValue, returnValue.Capacity, FilePath);

            if (length == 0 && returnValue.ToString() == "")
            {
                return null; // 键不存在
            }

            return returnValue.ToString();
        }
    }
}
