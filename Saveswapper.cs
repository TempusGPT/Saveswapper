using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Saveswapper
{
    public static class Saveswapper
    {
        public static void Swap(Save sourceSave, Save destSave)
        {
            var sourceSaveDirectory = GetLatestFileSystem(sourceSave.Children) as DirectoryInfo;
            var destSaveDirectory = GetLatestFileSystem(destSave.Children) as DirectoryInfo;
            var sourceSaveFile = GetLatestFileSystem(GetBiggestFiles(sourceSaveDirectory)) as FileInfo;
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
    }
}
