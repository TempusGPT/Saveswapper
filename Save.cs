using System.IO;
using System;

namespace Saveswapper
{
    public class Save
    {
        public static readonly string Path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\Packages\Microsoft.SunriseBaseGame_8wekyb3d8bbwe\SystemAppData\wgs";

        public string ID { get; }
        public DirectoryInfo Directory { get; }

        public Save(string id, DirectoryInfo directory)
        {
            ID = id;
            Directory = directory;
        }
    }
}
