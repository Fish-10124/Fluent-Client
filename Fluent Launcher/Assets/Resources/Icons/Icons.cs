using Microsoft.UI.Xaml.Media.Imaging;
using System;

namespace Fluent_Launcher.Assets.Resources.Icons
{
    public static class Icons
    {
        private const string Icon_Path = "ms-appx:///Assets/Resources/Icons/";

        public static readonly BitmapImage Crafting_Table = new(new Uri(Icon_Path + "crafting_table_front.png")),
                                           Dirt_Path = new(new Uri(Icon_Path + "dirt_path_side.png")),
                                           Fabric_Icon = new(new Uri(Icon_Path + "FabricIcon.png")),
                                           Forge_Icon = new(new Uri(Icon_Path + "ForgeIcon.png")),
                                           Furnace = new(new Uri(Icon_Path + "furnace_front.png")),
                                           Grass_Block = new(new Uri(Icon_Path + "grass_block_side.png")),
                                           NeoForge_Icon = new(new Uri(Icon_Path + "NeoForgeIcon.png")),
                                           OptiFabric_Icon = new(new Uri(Icon_Path + "OptiFabricIcon.png")),
                                           OptiFine_Icon = new(new Uri(Icon_Path + "OptiFineIcon.png")),
                                           Quilt_Icon = new(new Uri(Icon_Path + "QuiltIcon.png")),
                                           Steve = new(new Uri(Icon_Path + "steve.png"));

    }
}
