﻿using System;
using SFML.Window;
using GameConsoleSimulator.Util;
using GameConsoleSimulator.View;

namespace GameConsoleSimulator.Config
{
    using Resolution = Size;

    public static class Configuration
    {
        public const Mouse.Button ButtonMain = Mouse.Button.Left;
    
        public static readonly TrueColor WindowBackgroundColor = new TrueColor(0x18, 0x18, 0x18, 0x7F);
    
        public static readonly TrueColor WindowForegroundColor = new TrueColor(0, 196, 240, 0);
    
        public static Resolution MainWindowSize { get; } = DisplayData.getScreenResolution() / 2;

        public static readonly Resolution BoardResolution = new Resolution {Width = 1440, Height = 1440};

        public const float PieceScaleRelativeToSquare = 0.75f;

        public const string MainFontFilePath = "./Assets/Fonts/RobotoMono-Regular.ttf";
 
        public const uint DefaultTextCharacterSize = 60;

        public static readonly TimeSpan RefreshTime = TimeSpan.FromMilliseconds(8);
    }    

}

