using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Runtime.CompilerServices;

namespace lab3
{
    class Task1
    {
        public static void Start()
        {
            double sum = 0;
            int count = 0;

            using (StreamWriter swNoFile = new StreamWriter("no_file.txt"))
            using (StreamWriter swBadData = new StreamWriter("bad_data.txt"))
            using (StreamWriter swOverflow = new StreamWriter("overflow.txt"))

                for (int i = 10; i < 30; i++)
                { 
                
                    try
                    {
                      
                        using (StreamReader sr = new StreamReader($"{i}.txt"))
                        {
                            int n1 = int.Parse(sr.ReadLine());
                            int n2 = int.Parse(sr.ReadLine());
                            //  (int, int) pair = (n1, n2);
                            try
                            {
                                int multiply; checked { multiply = n1 * n2; }
                                Console.WriteLine($"Result of multiplication in file {i}.txt: {multiply}");
                                sum += multiply;
                                count++;
                            }
                            catch (OverflowException ex)
                            {
                                swOverflow.WriteLine($"{i}.txt");
                                Console.WriteLine($"File {i}.txt: Int overflow during multiplication\n{ex.Message}");
                            }
                        }
                    }
                    catch (FileNotFoundException ex)
                    {

                        swNoFile.WriteLine($"{i}.txt");
                        Console.WriteLine($"File {i}.txt not found\n{ex.Message}");
                    }
                    catch (ArgumentNullException ex)
                    {
                        swBadData.WriteLine($"{i}.txt");
                        Console.WriteLine($"File {i}.txt has bad data\n{ex.Message}");
                    }
                    catch (EndOfStreamException ex)
                    {
                        swBadData.WriteLine($"{i}.txt");
                        Console.WriteLine($"File {i}.txt has bad data\n{ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        swBadData.WriteLine($"{i}.txt");
                        Console.WriteLine($"Data in file {i}.txt is bad\n{ex.Message}");
                    }
                    catch (OverflowException ex)
                    {
                        swBadData.WriteLine($"{i}.txt");
                        Console.WriteLine($"File {i}.txt: Int overflow\n{ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            $"File {i}.txt has not predefined error\n{ex.Message}");
                        Environment.Exit(0);
                    }
            }
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Files' avarege: {sum / count}");
        }
    }
}
