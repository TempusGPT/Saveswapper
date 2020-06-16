using System.Collections.Generic;
using System.Linq;
using System;

namespace Saveswapper
{
    public class Program
    {
        private static void Main()
        {
            int index = 1;
            var saves = Save.Enumerate();

            foreach (var save in saves)
            {
                Console.WriteLine($"{index}\t{save.Directory.LastWriteTime}\t{save.Directory.Name}");
                index++;
            }
            Console.WriteLine();

            Console.Write("Source save index: ");
            var sourceSave = ReadSaveIndex(saves);
            Console.Write("Destination save index: ");
            var destSave = ReadSaveIndex(saves);

            Saveswapper.Swap(sourceSave, destSave);
            Console.Write("Saveswapping is complete.");
            Console.ReadKey(true);
        }

        private static Save ReadSaveIndex(IEnumerable<Save> saves)
        {
            try
            {
                var saveIndex = int.Parse(Console.ReadLine());
                return saves.First(save => save.Index == saveIndex);
            }
            catch (Exception)
            {
                Console.Write("Invalid index! Enter again: ");
                return ReadSaveIndex(saves);
            }
        }
    }
}
