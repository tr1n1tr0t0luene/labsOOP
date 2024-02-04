﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix1 = new MyMatrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            MyMatrix matrix2 = new MyMatrix(new double[,] { { 9, 8, 7 }, { 6, 5, 4 }, { 3, 2, 1 } });

            MyMatrix result = matrix1 * matrix2;

            Console.WriteLine(result.ToString());


            double[,] data = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            MyMatrix matrixData = new MyMatrix(data);

            Console.WriteLine(matrixData);

            Console.WriteLine("\n\n");
            Console.WriteLine("TEST");
            double[][] test = new double[][]
               {
                    new double[] { 1, 2, 3 },
                    new double[] { 4, 5, 6 },
                    new double[] { 7, 8, 9 }
               };

            MyMatrix test1 = new MyMatrix(test);

            MyMatrix transponeMatrix = test1.GetTransponedCopy();

            Console.WriteLine(transponeMatrix);

            try
            {

                double[][] jaggedMatrix = new double[][]
                {
                    new double[] { 1, 2, 7 },
                    new double[] { 4, 5, 6 },
                    new double[] { 7, 8, 9 }
                };


                MyMatrix matrixJagged = new MyMatrix(jaggedMatrix);

                Console.WriteLine(matrixJagged);


            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"{ex.Message}");
            }


            Console.WriteLine("\n\n");

            string[] stringArr = { "1 2    3", "4 5 6", "7 8 9" };

            MyMatrix stringMatrix = new MyMatrix(stringArr);

            Console.WriteLine(stringMatrix);



            string matrix = "1 2   3\n 4  5  6\n 7 8 9";

            MyMatrix line = new MyMatrix(matrix);

            Console.WriteLine(line);

            Console.ReadKey();

        }
    }
}
