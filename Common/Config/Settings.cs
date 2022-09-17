using System.IO;

namespace Snakey.Config
{
    public static class Settings
    {
        private static string BaseDirectory { get; } = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        public static int CellSize { get; } = 40;
        public static int WindowWidth { get; } = 800;
        public static int WindowHeight { get; } = 600;
        public static int ObstacleCount { get; } = 10;
        public static int UpdateTimer { get; } = 100;
        public static int MaximumSnackCount { get; } = 5;
        public static string AssetFolder { get; } = Path.Combine(BaseDirectory, @"Snakey\assets");
        public static bool EnableSoundEffects { get; } = false;
        public static string LogFolder { get; } = Path.Combine(BaseDirectory, @"Snakey\logs");
        public static string ServerIPAddress { get; } = "http://localhost:5000";
    }
}
