using System.IO;
using System;

/**
 * Created by CorArmstrong on 11.07.2016.
 */

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

        Console.WriteLine("\nFirst matrix: [{0}][{1}]\n", matrix1.length, matrix1[0].length);
        PrintArray(matrix1);

        Console.WriteLine("\nSecond matrix: [{0}][{1}]\n", matrix2.length, matrix2[0].length);
        PrintArray(matrix2);

        int[,] matrixProduct = PerformMatrixProduct(matrix1, matrix2);

        Console.WriteLine("\nMatrix product: [{0}][{1}]\n", matrixProduct.length, matrixProduct[0].length);
        PrintArray(matrixProduct);
    }
    
    static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        int[,] tempArr = new int[rows][cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                tempArr[i, j] = random.nextInt(INT_RANDOM_RANGE_BOUND);
            }
        }

        return tempArr;
    }

    static int[,] PerformMatrixProduct(int[,] matrix1, int[,] matrix2) {

        int matrix1_rows = matrix1.length;
        int matrix2_cols = matrix2[0].length;

        int matrix1_cols = matrix1[0].length;

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
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[0].Length; j++)
            {
                Console.Write("[{0}]  ", arr[i, j]);
            }
            Console.WriteLine();
        }
    }
}
