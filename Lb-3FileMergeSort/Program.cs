using System;
using System.IO;

namespace Lb_3FileMergeSort
{
    class Program
    {
        const string FILE_NAME = "file.bin";
        static void Main(string[] args)
        {
            GenerateFile(FILE_NAME, 100_000);
            Console.WriteLine("До сортировки (первые 1000 элементов): ");
            OutputData(FILE_NAME);
            var dm = new DirectMerge(FILE_NAME);
            dm.Sort();
            Console.WriteLine("После сортировки (первые 1000 элементов): ");
            OutputData(FILE_NAME);
            Console.ReadLine();
        }

        public static void GenerateFile(string file, long size)
        {
            using (var bw = new BinaryWriter(File.Create(file, 65536)))
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    bw.Write(rnd.Next(0, 1000));
                }
            }
        }

        public static void OutputData(string file, int count = 1000)
        {
            using (var br = new BinaryReader(File.Open(file, FileMode.Open)))
            {

                for (int i = 0; i < count; i++)
                {
                    if (br.BaseStream.Position == br.BaseStream.Length)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"{br.ReadInt32()} ");
                    }
                }

            }
        }
    }

}