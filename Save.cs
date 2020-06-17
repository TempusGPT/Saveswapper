using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace Saveswapper
{
    public class Save
    {
        public static readonly string Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";
        public static readonly IEnumerable<DirectoryInfo> directories = from directory in new DirectoryInfo(Path).EnumerateDirectories()
                                                                        where directory.Name != "t"
                                                                        orderby directory.LastWriteTime descending
                                                                        select directory;

        private Save(int index, DirectoryInfo directory)
        {
            Index = index;
            Name = directory.Name;
            LastModified = directory.LastWriteTime;
            Children = directory.EnumerateDirectories();
        }

        public int Index { get; }
        public string Name { get; }
        public DateTime LastModified { get; }
        public IEnumerable<DirectoryInfo> Children { get; }

        public static IEnumerable<Save> Enumerate()
        {
            int index = 1;
            foreach (var directory in directories)
            {
                yield return new Save(index, directory);
                index++;
            }
        }
    }
}
