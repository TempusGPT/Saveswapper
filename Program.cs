using System.Linq;
using System;

namespace Saveswapper
{
    public class Program
    {
        // 1. SavePath에 있는 t를 제외한 디렉토리를 수정 날짜와 함께 열거
        // 2. 번호를 선택하면 스왑

        private static void Main()
        {
            int index = 1;
            var saves = SaveEnumerator.Enumerate();

            foreach (var save in saves)
            {
                Console.WriteLine($"{index}\t{save}");
                index++;
            }

            Console.Write("Source save index: ");
            var sourceSaveIndex = int.Parse(Console.ReadLine());
            var sourceSave = saves.First(save => save.Index == sourceSaveIndex);

            Console.Write("Destination save index: ");
            var destSaveIndex = int.Parse(Console.ReadLine());
            var destSave = saves.First(save => save.Index == destSaveIndex);

            Saveswapper.Swap(sourceSave, destSave);
            Console.Write("Saveswapping is complete.");
            Console.ReadKey(true);
        }
    }
}
