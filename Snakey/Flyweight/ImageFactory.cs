using Snakey.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace Snakey.Flyweight
{
    static class ImageFactory
    {
        private static Dictionary<string, BitmapImage> _cache = new();
        public static BitmapImage GetImage(string imageName)
        {
            if (_cache.ContainsKey(imageName))
                return _cache[imageName];

            var fullPath = Path.Combine(Settings.AssetFolder, imageName);
            BitmapImage image = new(new Uri(fullPath));
            _cache.Add(imageName, image);

            return image;
        }
    }
}
