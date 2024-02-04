using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;

namespace laba3
{
     class Task1
    {
        internal class Comparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return (x.Substring(0, 2)).CompareTo(y.Substring(0, 2));
            }
        }
        public static void Start()
        {
            double sum = 0;
            int counter = 0;

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader($"{i}{j}.txt"))
                        {
                            int num1 = int.Parse(reader.ReadLine());
                            int num2 = int.Parse(reader.ReadLine());
                            try
                            {
                                int multiply; checked { multiply = num1 * num2; }
                                Console.WriteLine($"Добуток чисел у файлi {i}{j}.txt: {multiply}");
                                sum += multiply;
                                counter += 1;
                            }
                            catch (OverflowException e)
                            {
                                WriteInFile("overflow.txt", i, j);
                                Console.WriteLine(
                                    $"Файл {i}{j}.txt: вiдбулося переповнення типу Int при множеннi чисел\n{e.Message}");
                            }
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        WriteInFile("no_file.txt", i, j);
                        Console.WriteLine($"Файл {i}{j}.txt вiдсутнiй\n{e.Message}");
                    }
                    catch (ArgumentNullException e)
                    {
                        WriteInFile("bad_data.txt", i, j);
                        Console.WriteLine($"Файл {i}{j}.txt не вiдповiдає умовi\n{e.Message}");
                    }
                    catch (EndOfStreamException e)
                    {
                        WriteInFile("bad_data.txt", i, j);
                        Console.WriteLine($"Файл {i}{j}.txt не вiдповiдає умовi\n{e.Message}");
                    }
                    catch (FormatException e)
                    {
                        WriteInFile("bad_data.txt", i, j);
                        Console.WriteLine($"Данi в файлi {i}{j}.txt не вiдповiдають умовi\n{e.Message}");
                    }
                    catch (OverflowException e)
                    {
                        WriteInFile("bad_data.txt", i, j);
                        Console.WriteLine($"Файл {i}{j}.txt: вiдбулося переповнення типу Int\n{e.Message}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(
                            $"З файлом {i}{j}.txt сталася помилка не передумовлена заздалегiдь:\n{e.Message}");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"Сума добуткiв: {sum}");
            Console.WriteLine($"Середнє арифметичне добуткiв: {sum / counter}");
        }

        static List<string> ReadFile(string fileName)
        {
            List<string> list = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
                list.Add(reader.ReadLine());
            }

            RemoveAllNulles(list);
                    
            return list;
        }

        static void WriteInFile(string fileName, int i, int j)
        {
            try
            {
                List<string> list = ReadFile(fileName);
                list.Add($"{i}{j}.txt");
                list = list.Distinct().ToList();
                list.Sort(new Comparer());
                

                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    try
                    {
                        WriteElements(list, writer);
                    }
                    catch
                    {
                    }
                }
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter writer = new StreamWriter(fileName, false))
                {
                    writer.WriteLine($"{i}{j}.txt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Перевiрте файл {fileName}:\n{e.Message}");
                Environment.Exit(0);
            }
        }

        static void RemoveAllNulles(List<string> list)
        {
           
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
            list.Remove(null);
        }

        static void WriteElements(List<string> list, StreamWriter writer)
        {
           
            writer.WriteLine(list[0]);
            writer.WriteLine(list[1]);
            writer.WriteLine(list[2]);
            writer.WriteLine(list[3]);
            writer.WriteLine(list[4]);
            writer.WriteLine(list[5]);
            writer.WriteLine(list[6]);
            writer.WriteLine(list[7]);
            writer.WriteLine(list[8]);
            writer.WriteLine(list[9]);
            writer.WriteLine(list[10]);
            writer.WriteLine(list[11]);
            writer.WriteLine(list[12]);
            writer.WriteLine(list[13]);
            writer.WriteLine(list[14]);
            writer.WriteLine(list[15]);
            writer.WriteLine(list[16]);
            writer.WriteLine(list[17]);
            writer.WriteLine(list[18]);
            writer.WriteLine(list[19]);
        }
    }
}
 