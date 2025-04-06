using Fluent_Launcher.Assets.Class;
using Fluent_Launcher.Assets.Resources.Icons;
using Microsoft.UI.Xaml.Media.Imaging;
using MinecraftLaunch.Base.Enums;
using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    }
}
