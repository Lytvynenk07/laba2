using System;

namespace lab2_1_sem_2_kurs_oop
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a number of task(1 or 2): ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                default:
                    break;
            }
        }
        //double[,] data = { { 1, 2, 3 }, { 4, 5, 6 } };
        //MyMatrix matrixFrom2DArray = new MyMatrix(data);

        //double[][] jaggedArray = new double[][] { new double[] { 1, 2 }, new double[] { 3, 4, 5 } };
        //MyMatrix matrixFromJaggedArray = new MyMatrix(jaggedArray);

        //string[] stringData = { "1 2 3", "4 5 6" };
        //MyMatrix matrixFromStringArray = new MyMatrix(stringData);

        static void Task1()
        {
            //double[,] data = { { 1, 2, 3 }, { 4, 5, 6 } };
            //MyMatrix matrixA = new MyMatrix(data);
            //double[][] jaggedArray = new double[][] { new double[] { 1, 2 }, new double[] { 3, 4, 5 } };
            //MyMatrix matrixA = new MyMatrix(jaggedArray);
            //string[] stringData = { "1 2 3", "4 5 6" };
            //MyMatrix matrixA = new MyMatrix(stringData);

            string a = "4 5    6 \n 6    7 6 \n 6 7     2";

            MyMatrix matrixA = new MyMatrix(a);
            Console.WriteLine(matrixA);

            double[,] dataB = { { 7, 8, 2 }, { 10, 11, 3 }, { 5, 7, 4 } };
            MyMatrix matrixB = new MyMatrix(dataB);

            Console.WriteLine("Matrix A:");
            Console.WriteLine(matrixA);

            Console.WriteLine("\nMatrix B:");
            Console.WriteLine(matrixB);

            MyMatrix sum = matrixA + matrixB;
            Console.WriteLine("\nMatrix A + B:");
            Console.WriteLine(sum);

            MyMatrix product = matrixA * matrixB;
            Console.WriteLine("\nMatrix A * B:");
            Console.WriteLine(product);

            matrixA.TransposeMe();
            Console.WriteLine("\nTransposed Matrix A:");
            Console.WriteLine(matrixA);

            MyMatrix transposedB = matrixB.GetTransposedCopy();
            Console.WriteLine("\nTransposed Matrix B (copy):");
            Console.WriteLine(transposedB);
        }
        static void Task2()
        {
            MyTime currentTime = new MyTime(24, 59, 59);
            Console.WriteLine("Current Time: " + currentTime);

            MyTime newTime1 = currentTime.AddSeconds(3600); // Add 1 hour.
            MyTime newTime2 = currentTime.AddMinutes(30);  // Add 30 minutes.
            MyTime newTime3 = currentTime.AddHours(2);     // Add 2 hours.

            Console.WriteLine("New Time (Add 1 hour): " + newTime1);
            Console.WriteLine("New Time (Add 30 minutes): " + newTime2);
            Console.WriteLine("New Time (Add 2 hours): " + newTime3);

            MyTime otherTime = new MyTime(10, 30, 15); // 10:30:15
            int timeDifference = currentTime.Difference(otherTime);
            Console.WriteLine($"Time Difference with {otherTime}: " + timeDifference + " seconds");

            Console.WriteLine("Now is: ");

            Console.WriteLine(currentTime.WhatLesson());
        }
    }
}
