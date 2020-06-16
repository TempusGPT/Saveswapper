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
            Console.WriteLine("Index\tLast modified\tDirectory");

            foreach (var save in SaveEnumerator.Enumerate())
            {
                Console.WriteLine($"{index:D2}\t{save}");
                index++;
            }

            Console.Write("Source save index: ");
            var sourceSaveName = Console.ReadLine();
            Console.Write("Destination save index: ");
            var destSaveName = Console.ReadLine();

            Saveswapper.Swap(sourceSaveName, destSaveName);
            Console.Write("Saveswapping is complete.");
            Console.ReadKey(true);
        }
    }
}
