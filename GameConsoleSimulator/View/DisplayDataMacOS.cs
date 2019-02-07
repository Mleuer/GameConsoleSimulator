﻿using SFML.Window;
using MonoMac.CoreVideo;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.View
{
    public static class DisplayData
    {

        public static Size getScreenResolution()
        {
            VideoMode currentVideoMode = VideoMode.DesktopMode;
            return new Size(currentVideoMode.Width, currentVideoMode.Height);
        }

        public static double getScreenRefreshRate()
        {
            var display = new CVDisplayLink();
            return display.ActualOutputVideoRefreshPeriod;
        }

        /**
         * The display scaling factor.
         * For example, if the system is running in Retina mode,
         * this value will be 2.0
         */
        public static float getDisplayScalingFactor()
        {
            //todo: implement without hard-coded values
            return 2.0f;
        }

    }
}
