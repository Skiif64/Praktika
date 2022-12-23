using System;
using System.IO;

namespace Lb_3FileMergeSort
{
    public class DirectMerge
    {
        public string FileInput { get; set; }
        private long _iterations;
        private long _segments;

        public DirectMerge(string input)
        {
            FileInput = input;
            _iterations = 1;
        }

        public void Sort()
        {
            while (true)
            {
                Console.Write(".");
                SplitToFiles();

                if (_segments == 1)
                {
                    break;
                }
                MergePairs();
            }
            Console.WriteLine();
        }

        private void SplitToFiles()
        {
            _segments = 1;
            using (var br = new BinaryReader(File.OpenRead(FileInput)))
            using (var writerA = new BinaryWriter(File.Create("a.bin", 65536)))
            using (var writerB = new BinaryWriter(File.Create("b.bin", 65536)))
            {
                long counter = 0;
                bool flag = true;

                long length = br.BaseStream.Length;
                long position = 0;
                while (position != length)
                {

                    if (counter == _iterations)
                    {
                        flag = !flag;
                        counter = 0;
                        _segments++;
                    }

                    int element = br.ReadInt32();
                    position += 4;
                    if (flag)
                    {
                        writerA.Write(element);
                    }
                    else
                    {
                        writerB.Write(element);
                    }
                    counter++;
                }
            }
        }

        private void MergePairs()
        {
            using (var readerA = new BinaryReader(File.OpenRead("a.bin")))
            using (var readerB = new BinaryReader(File.OpenRead("b.bin")))
            using (var bw = new BinaryWriter(File.Create(FileInput, 65536)))
            {
                long counterA = _iterations, counterB = _iterations;
                int elementA = 0, elementB = 0;
                bool pickedA = false, pickedB = false, endA = false, endB = false;
                long lengthA = readerA.BaseStream.Length;
                long lengthB = readerB.BaseStream.Length;
                long positionA = 0;
                long positionB = 0;
                while (!endA || !endB)
                {
                    if (counterA == 0 && counterB == 0)
                    {
                        counterA = _iterations;
                        counterB = _iterations;
                    }

                    if (positionA != lengthA)
                    {
                        if (counterA > 0 && !pickedA)
                        {
                            elementA = readerA.ReadInt32();
                            positionA += 4;
                            pickedA = true;
                        }
                    }
                    else
                    {
                        endA = true;
                    }

                    if (positionB != lengthB)
                    {
                        if (counterB > 0 && !pickedB)
                        {
                            elementB = readerB.ReadInt32();
                            positionB += 4;
                            pickedB = true;
                        }
                    }
                    else
                    {
                        endB = true;
                    }

                    if (pickedA)
                    {
                        if (pickedB)
                        {
                            if (elementA < elementB)
                            {
                                bw.Write(elementA);
                                counterA--;
                                pickedA = false;
                            }
                            else
                            {
                                bw.Write(elementB);
                                counterB--;
                                pickedB = false;
                            }
                        }
                        else
                        {
                            bw.Write(elementA);
                            counterA--;
                            pickedA = false;
                        }
                    }
                    else if (pickedB)
                    {
                        bw.Write(elementB);
                        counterB--;
                        pickedB = false;
                    }
                }

                _iterations *= 2;
            }
        }
    }

}