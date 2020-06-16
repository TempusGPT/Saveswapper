using System.IO;
using System;

namespace Saveswapper
{
    public class Save
    {
        public static readonly string Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";

        public int Index { get; }
        public DirectoryInfo Directory { get; }

        public Save(int index, DirectoryInfo directory)
        {
            Index = index;
            Directory = directory;
        }
    }
}
