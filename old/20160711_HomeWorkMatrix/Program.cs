using System.IO;
using System;

namespace _20160711_HomeWorkMatrix
{
    class Program
    {
        static Random random = new Random();

        static int ROWS1 = 4;
        static int ROWS2 = 5;
        static int COLS = 3;
        static int INT_RANDOM_RANGE_BOUND = 400;

        static void Main()
        {
            Console.WriteLine("< Matrix product example >");

            // Правило произведения матриц:
            // Если число столбцов в первой матрице равно числу строк во второй

            int[,] matrix1 = GenerateRandomMatrix(ROWS1, COLS);
            int[,] matrix2 = GenerateRandomMatrix(COLS, ROWS2);

            Console.WriteLine("\nFirst matrix: [{0}][{1}]\n", matrix1.GetLength(0), matrix1.GetLength(1));
            PrintArray(matrix1);

            Console.WriteLine("\nSecond matrix: [{0}][{1}]\n", matrix2.GetLength(0), matrix2.GetLength(1));
            PrintArray(matrix2);

            int[,] matrixProduct = PerformMatrixProduct(matrix1, matrix2);

            Console.WriteLine("\nMatrix product: [{0}][{1}]\n", matrixProduct.GetLength(0), matrixProduct.GetLength(1));
            PrintArray(matrixProduct);

            // HanoiTowers:
            Console.WriteLine();
            HanoiTowers towers = new HanoiTowers();
            towers.ExecuteMain();
            Console.ReadKey();
        }

        static int[,] GenerateRandomMatrix(int rows, int cols)
        {
            int[,] tempArr = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    tempArr[i, j] = random.Next(-INT_RANDOM_RANGE_BOUND, INT_RANDOM_RANGE_BOUND);
                }
            }

            return tempArr;
        }

        static int[,] PerformMatrixProduct(int[,] matrix1, int[,] matrix2)
        {

            int matrix1_rows = matrix1.GetLength(0);
            int matrix2_cols = matrix2.GetLength(1);

            int matrix1_cols = matrix1.GetLength(1);

            int[,] productMatrix = new int[matrix1_rows, matrix2_cols];

            // Элемент Xij на пересечении строки i и столбца j результирующей матрицы является
            // скалярным произведением i-й строки первой матрицы и j-го столбца второй матрицы.

            for (int i = 0; i < matrix1_rows; i++)
            {
                for (int j = 0; j < matrix2_cols; j++)
                {
                    productMatrix[i, j] = 0;

                    for (int k = 0; k < matrix1_cols; k++)
                    {
                        productMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return productMatrix;
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("[{0, 8}]  ", arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

}
