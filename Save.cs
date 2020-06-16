using System.Collections.Generic;
using System.IO;
using System;

namespace Saveswapper
{
    public class Save
    {
        public static readonly string Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";
        public static IEnumerable<DirectoryInfo> directories;

        static Save()
        {
            
        }

        private Save(int index, DirectoryInfo directory)
        {
            Index = index;
            Directory = directory;
        }

        public int Index { get; }
        public DirectoryInfo Directory { get; }

        public static IEnumerable<Save> Enumerate()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return null;
            }
        }
    }
}
