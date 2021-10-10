﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Config
{
    static class Settings
    {
        public static int CellSize { get; } = 40;
        public static int WindowWidth { get; } = 800;
        public static int WindowHeight { get; } = 600;
        public static int ObstacleCount { get; } = 10;
        public static int UpdateTimer { get; } = 100;
        public static int MaximumSnackCount { get; } = 3;
    }
}
