using System;
using GameConsoleSimulator.Util;
using GameConsoleSimulator.View;

using static GameConsoleSimulator.Util.Util;

namespace GameConsoleSimulator.Config
{
    using Resolution = Size;

    public static class Configuration
    {
        public static Resolution MainWindowSize { get; } = DisplayData.getScreenResolution() / 2;

        public const string MainFontFilePath = "./Assets/Fonts/RobotoMono-Regular.ttf";
 
        public const uint DefaultTextCharacterSize = 60;

        public static readonly TimeSpan RefreshInterval = TimeSpan.FromMilliseconds(8);

        public static readonly String AssetFileDirectoryPath = GetApplicationDirectoryPath() + $"{Slash}Assets";
        public static readonly String ImageFileDirectoryPath = $"{AssetFileDirectoryPath}{Slash}Bitmaps";
        public static readonly String SoundFileDirectoryPath = $"{AssetFileDirectoryPath}{Slash}Sounds";
    }    

}

