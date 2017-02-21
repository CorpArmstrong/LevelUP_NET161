package com.corparmstrong.net161;

import java.util.Scanner;

/**
 * Created by CorArmstrong on 11.07.2016.
 */

/*
 Данная процедура переносит N дисков со стержня A на стержень C
 пользуясь B как вспомогательным, соблюдая правила.
 процедура "Перенести" (A, B, C, N)

     начало

        если N=1

        // Если диск всего один, то надо его перенести напрямую

        то

            снять диск со стержня A и положить на стержень C;

            возврат из процедуры;

        иначе

            // Переносим все диски, кроме самого большога со стежня

            // A на стержень B

            Перенести (A,C,B,N-1);

            // Переносим самый большой диск со стержня A на стержень C

            снять диск со стержня A и положить на стержень C;

            // Переносим все диски со стержня B на стержень C поверх

            // самого большого диска

            Перенести (B,A,C,N-1);

            возврат из процедуры;

        конец если;

     конец процедуры "Перенести";
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
