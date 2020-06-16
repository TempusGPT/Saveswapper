using System.Net;
using System.Linq;
using System.IO;
using System;

namespace Saveswapper
{
    public class Program
    {
        private static void Main()
        {
        }
    }

    public static class Saveswapper
    {
        private static readonly string SavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";

        public static void Swap(string sourceSaveName, string destSaveName)
        {
            var sourceSaveDirectories = new DirectoryInfo($@"{SavePath}\{sourceSaveName}").GetDirectories();
            
        }

        private static DirectoryInfo LatestDirectory(DirectoryInfo[] directories)
        {
            return directories.Aggregate((current, next) => current.LastWriteTime > next.LastWriteTime ? current : next);
        }
    }
}
