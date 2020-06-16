using System.Diagnostics;
using System;

namespace Saveswapper
{
    public class Program
    {
        private static void Main()
        {
            Process.Start("explorer.exe", Saveswapper.SavePath);

            Console.Write("Source save name: ");
            var sourceSaveName = Console.ReadLine();
            Console.Write("Destination save name: ");
            var destSaveName = Console.ReadLine();

            Saveswapper.Swap(sourceSaveName, destSaveName);
        }
    }
}
