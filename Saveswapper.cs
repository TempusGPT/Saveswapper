using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Saveswapper
{
    public static class Saveswapper
    {
        private static readonly string SavePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";

        public static void Swap(string sourceSaveName, string destSaveName)
        {
            var sourceSaveDirectory = GetSaveDirectory(sourceSaveName);
            var sourceSaveFile = GetLatestFileSystem(GetBiggestFiles(sourceSaveDirectory)) as FileInfo;
            var destSaveDirectory = GetSaveDirectory(destSaveName);
            var destSaveFiles = GetBiggestFiles(destSaveDirectory);

            foreach (var destSaveFile in destSaveFiles)
            {
                sourceSaveFile.CopyTo(destSaveFile.FullName, true);
            }
        }

        private static FileSystemInfo GetLatestFileSystem(IEnumerable<FileSystemInfo> fileSystems)
        {
            return fileSystems.Aggregate((current, next) => current.LastWriteTime > next.LastWriteTime ? current : next);
        }

        private static IEnumerable<FileInfo> GetBiggestFiles(DirectoryInfo directory)
        {
            var files = directory.EnumerateFiles().OrderByDescending(file => file.Length);
            var biggestFileLength = files.First().Length;
            return files.TakeWhile(file => file.Length == biggestFileLength);
        }

        private static DirectoryInfo GetSaveDirectory(string saveName)
        {
            return GetLatestFileSystem(new DirectoryInfo($@"{SavePath}\{saveName}").EnumerateDirectories()) as DirectoryInfo;
        }
    }
}
