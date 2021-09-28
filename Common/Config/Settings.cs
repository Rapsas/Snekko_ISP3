using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Config
{
    static class Settings
    {
        public static int CellSize { get; } = 40;
        public static int UpdateTimer { get; } = 100;
        public static int MaximumSnackCount { get; } = 50;
    }
}
