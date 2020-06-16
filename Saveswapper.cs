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
            var sourceSaveDirectory = GetLatestFileSystem(sourceSave.Children);
            var destSaveDirectory = GetLatestFileSystem(destSave.Children);
            var sourceSaveFile = GetLatestFileSystem(GetBiggestFiles(sourceSaveDirectory));
            var destSaveFiles = GetBiggestFiles(destSaveDirectory);

            var backup = GetLatestFileSystem(destSaveFiles);
            backup.CopyTo($@"{backup.Directory.Parent.FullName}\BACKUP", true);

            foreach (var destSaveFile in destSaveFiles)
            {
                sourceSaveFile.CopyTo(destSaveFile.FullName, true);
            }
        }

        private static T GetLatestFileSystem<T>(IEnumerable<T> fileSystems) where T : FileSystemInfo
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
