package com.corparmstrong.net161;

import java.util.Random;

/**
 * Created by CorpArmstrong on 10.07.2016.
 */
public class MatrixProduct {

    public static Random random = new Random();

    public static final int ROWS1 = 4;
    public static final int ROWS2 = 5;
    public static final int COLS = 3;
    public static final int INT_RANDOM_RANGE_BOUND = 400;

    public static void main(String[] args) {
        System.out.println("< Matrix product example >");

        // Правило произведения матриц:
        // Если число столбцов в первой матрице равно числу строк во второй

        int[][] matrix1 = generateRandomMatrix(ROWS1, COLS);
        int[][] matrix2 = generateRandomMatrix(COLS, ROWS2);

        System.out.println(String.format("\nFirst matrix: [%d][%d]\n", matrix1.length, matrix1[0].length));
        printArray(matrix1);

        System.out.println(String.format("\nSecond matrix: [%d][%d]\n", matrix2.length, matrix2[0].length));
        printArray(matrix2);

        int[][] matrixProduct = performMatrixProduct(matrix1, matrix2);

        System.out.println(String.format("\nMatrix product: [%d][%d]\n", matrixProduct.length, matrixProduct[0].length));
        printArray(matrixProduct);
    }

    public static int[][] generateRandomMatrix(int rows, int cols) {

        int tempArr[][] = new int[rows][cols];

        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                tempArr[i][j] = random.nextInt(INT_RANDOM_RANGE_BOUND);
            }
        }

        return tempArr;
    }

    public static int[][] performMatrixProduct(int[][] matrix1, int[][] matrix2) {

        int matrix1_rows = matrix1.length;
        int matrix2_cols = matrix2[0].length;

        int matrix1_cols = matrix1[0].length;

        int productMatrix[][] = new int[matrix1_rows][matrix2_cols];

        // Элемент Xij на пересечении строки i и столбца j результирующей матрицы является
        // скалярным произведением i-й строки первой матрицы и j-го столбца второй матрицы.

        for (int i = 0; i < matrix1_rows; i++) {
            for (int j = 0; j < matrix2_cols; j++) {
                productMatrix[i][j] = 0;
                for (int k = 0; k < matrix1_cols; k++) {
                    productMatrix[i][j] += matrix1[i][k] * matrix2[k][j];
                }
            }
        }

        return productMatrix;
    }

    static void printArray(int[][] arr) {
        for (int i = 0; i < arr.length; i++) {
            for (int j = 0; j < arr[0].length; j++) {
                System.out.print(String.format("[%1$d]  ", arr[i][j]));
            }
            System.out.println();
        }
    }
}
