using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Playground.projects.Threading.tplmatrix
{
    class Core
    {   
        Random rnd = new Random();

        public int[,] FillMatrix (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++) 
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = rnd.Next(1,4000);
                }
            }

            return matrix;
        }

        public void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine(matrix[i,j]);
                }
            }
        }

        public int FindMaxValInMatrixSimple(int[,] matrix)
        {
            int counter = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] > counter)
                        counter = matrix[i,j];
                }
            }

            return counter;
        } 
        


        public int OnePartOfMatrixHandler(int[,] matrix, int indexator = 0)
        {
            var task = Task.Run(() =>
            {
                int counter = 0;
                for (var i = indexator; i < matrix.GetLength(0) - indexator; i++)
                {
                    for (int j = 1; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] > counter)
                            counter = matrix[i, j];
                    }
                }
                return counter;
            });

            return task.Result;
        }

        public int FindMaxValTTTPLParallel(int[,] array)
        {
            int max = int.MinValue;
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            // Используем Parallel.For для параллельного поиска максимального элемента
            Parallel.For(0, rows, i =>
            {
                for (int j = 0; j < cols; j++)
                {
                    int element = array[i, j];
                    // Используем Interlocked.CompareExchange для атомарного обновления max
                    System.Threading.Interlocked.Exchange(ref max, Math.Max(max, element));
                }
            });

            return max;
        }

        public int FindMaxValInMatrixTPL(int[,] matrix)
        {
            const int numberOfParts = 10;

            var responses = new List<int>();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int part = rows / numberOfParts;

            for (int i = 1; i < numberOfParts + 1; i++)
            {
                responses.Add(OnePartOfMatrixHandler(matrix, part * i));
            }

            return responses.Order().ToList()[^1];

        }

    }

    class Program
    {
        public static void Start()
        {
            int[,] matrix = new int[10000, 10000];

            Core core = new Core();

            core.FillMatrix(matrix);

            //core.PrintMatrix(matrix);

            var timer = new Stopwatch();
            timer.Start();
            //var maxVal = core.FindMaxValInMatrixSimple(matrix);
            var maxVal = core.FindMaxValTTTPLParallel(matrix);
            timer.Stop();
            Console.WriteLine(maxVal);
            Console.WriteLine(timer.Elapsed);
        }
    }
}
