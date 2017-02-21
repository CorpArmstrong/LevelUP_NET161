package com.corparmstrong.net161;

import java.util.Scanner;

/**
 * Created by CorArmstrong on 11.07.2016.
 */

/*
 ������ ��������� ��������� N ������ �� ������� A �� �������� C
 ��������� B ��� ���������������, �������� �������.
 ��������� "���������" (A, B, C, N)

     ������

        ���� N=1

        // ���� ���� ����� ����, �� ���� ��� ��������� ��������

        ��

            ����� ���� �� ������� A � �������� �� �������� C;

            ������� �� ���������;

        �����

            // ��������� ��� �����, ����� ������ �������� �� ������

            // A �� �������� B

            ��������� (A,C,B,N-1);

            // ��������� ����� ������� ���� �� ������� A �� �������� C

            ����� ���� �� ������� A � �������� �� �������� C;

            // ��������� ��� ����� �� ������� B �� �������� C ������

            // ������ �������� �����

            ��������� (B,A,C,N-1);

            ������� �� ���������;

        ����� ����;

     ����� ��������� "���������";
*/

public class HanoiTowers {

    public static char a = 'A';
    public static char b = 'B';
    public static char c = 'C';
    public static int num = 0;

    public static void processHanoi(int num, char a, char b, char c) {
        if(num > 0) {
            processHanoi(num - 1, a, c, b);
            System.out.println(String.format("%c--->%c\n", a, c));
            processHanoi(num - 1, b, a, c);
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Enter number of rings: ");
        num = scanner.nextInt();
        System.out.println();
        processHanoi(num, a, b, c);
    }
}
