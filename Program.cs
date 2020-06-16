using System.Collections.Generic;
using System.Linq;
using System;

namespace Saveswapper
{
    public class Program
    {
        private static void Main()
        {
            foreach (var save in Save.Enumerate())
            {
                Console.WriteLine($"{save.Index} \t{save.LastModified} \t{save.Name}");
            }

            Console.Write("Source save index: ");
            var sourceSave = ReadSaveIndex(Save.Enumerate());
            Console.Write("Destination save index: ");
            var destSave = ReadSaveIndex(Save.Enumerate());

            Console.WriteLine($"Copying [{sourceSave.LastModified}] to [{destSave.LastModified}].");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey(true);

            Saveswapper.Swap(sourceSave, destSave);
            Console.WriteLine("Saveswapping is complete.");
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
