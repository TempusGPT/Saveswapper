using System.Collections.Generic;
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
            Saveswapper.Swap("000901F976A04C3F_000000000000000000000000765B6743", null);
        }
    }

    public static class Saveswapper
    {
        private static readonly string SavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";

        public static void Swap(string sourceSaveName, string destSaveName)
        {
            var sourceSaveDirectory = Latest<DirectoryInfo>(new DirectoryInfo($@"{SavePath}\{sourceSaveName}").EnumerateDirectories());
            var sourceSaveFile = Latest<FileInfo>(BiggestFiles(sourceSaveDirectory));
            Console.WriteLine(sourceSaveFile);
        }

        private static T Latest<T>(IEnumerable<FileSystemInfo> fileSystems) where T : FileSystemInfo
        {
            return fileSystems.Aggregate((current, next) => current.LastWriteTime > next.LastWriteTime ? current : next) as T;
        }

        private static IEnumerable<FileInfo> BiggestFiles(DirectoryInfo directory)
        {
            var files = directory.EnumerateFiles().OrderByDescending(file => file.Length);
            return files.TakeWhile(file => file.Length == files.First().Length);
        }
    }
}
