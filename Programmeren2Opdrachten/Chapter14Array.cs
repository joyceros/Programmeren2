﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Programmeren2Opdrachten
{
    class Chapter14Array
    {
        //1 Write a method to return the biggest item from a non-empty array of int. 
        //Provide some test cases to test your method.
        [Test]
        public void TestExercise1()
        {
            //write your own tests here
            int[] arraytest1 = {1,5,2,8};
            int[] arraytest2 = { 0, 5, 2, -1 };
            int[] arraytest3 = { -2, -1, 2, 0 };

            Assert.AreEqual(Exercise1(arraytest1), 8);
            Assert.AreEqual(Exercise1(arraytest2), 5);
            Assert.AreEqual(Exercise1(arraytest3), 2);


            Programmeren2Tests.Chapter14Test.TestExercise1(Exercise1);
        }

        public static int Exercise1(int[] xs)
        {
            int max = xs[0];
            for (int i = 0; i < xs.Length; i++)
            {
                if (xs[i] > max)
                {
                    max = xs[i];
                }
            }

            return max;
        }

        //2 Write a method to return the sum of all the odd numbers in an array of int. 
        //Provide some test cases to test your method.
        [Test]
        public void TestExercise2()
        {
            //write your own tests here
            Programmeren2Tests.Chapter14Test.TestExercise2(Exercise2);

            
            Assert.AreEqual(133, Exercise2(new int[] { 21, 0, 35, 77, 14 }));
            Assert.AreEqual(8, Exercise2(new int[] { 2, 0, 5, 3, 66 }));
        }

        public int Exercise2(int[] xs)
        {
            int sum = 0;
            foreach (int num in xs)
            {
                if (num % 2 != 0)
                {
                    sum += num;
                }
            }
            return sum;
        }

        //Write a method to search for a given target string in an array of strings. 
        //The method should return the index at which the target is found. 
        //If the target is not found, it should return -1. 
        //Provide test cases to test all the important cases: the target could match the first element or the last element in the array, or some element in the middle, or it may not exist in the array at all.
        [Test]
        public void TestExercise3()
        {
            //write your own tests here
            Programmeren2Tests.Chapter14Test.TestExercise3(Exercise3);


            string[] testarray1 = { "banana", "apple", "kiwi", "pear" };
            Assert.AreEqual(3, Exercise3(testarray1, "pear"));
            Assert.AreEqual(2, Exercise3(testarray1, "wi"));
            Assert.AreEqual(-1, Exercise3(testarray1, "pineapple"));

        }

        public static int Exercise3(string[] xs, string search)
        {
            int indexnum = 0;
            foreach(string s in xs)
            {
                if (s.IndexOf(search) != -1)
                {
                    return indexnum;
                }
                indexnum++;
            }
            return -1;
        }
    
        //Use the method above to write a method that turns a month name into a corresponding month number, 
        //so that these tests pass:
        //Assert.AreEqual(Exercise4("January"), 1);
        //Assert.AreEqual(Exercise4("June"), 6);
        //Assert.AreEqual(Exercise4("November"), 11);
        //Assert.AreEqual(Exercise4("NoveMber"), 11);
        [Test]
        public void TestExercise4()
        {
            Programmeren2Tests.Chapter14Test.TestExercise4(Exercise4);
            Assert.AreEqual(Exercise4("incorrectmonthtest"), -1);
        }

        public static int Exercise4(string month)
        {
            string monthNew = month.ToLower();
            string[] months = { "january", "february", "march", "april", "may", "june", "july", "august", "september", "october", "november", "december" };
            for (int i = 0; i < months.Length; i++ )
            {
                if (months[i] == monthNew)
                {
                    return i + 1;
                }
            }
            return -1;

        }

        //5 Assume we have this definition in our code:
        //int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //Write a method that takes a day number and a month name, 
        //and returns the day number within the (non-leap) year. 
        //Assume days are numbered starting from 0. For example, dayMonthToDay("March", 12) 
        //should give the result 71.
        [Test]
        public void TestExercise5()
        {
            Programmeren2Tests.Chapter14Test.TestExercise5(Exercise5);
        }

        public static int Exercise5(string month, int day)
        {
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int daynumber = 0;
            int monthNum = Exercise4(month) - 1;
            for (int i = 0; i < monthNum;  i ++)
            {
                daynumber = daynumber + daysInMonth[i];
            }
            return daynumber + day;
        }

        //6. Arrays can be used to represent mathematical vectors. 
        //In the next few exercises we will write methods to perform standard operations on vectors. 
        //Write C# code to pass the tests in each case.
        [Test]
        public void TestExercise6()
        {
            Assert.AreEqual(DotProduct(new double[] {1, 1}, new double[] {1, 1}),  2);
            Assert.AreEqual(DotProduct(new double[] {1, 4.5}, new double[] {1, 2}), 10);
            Assert.AreEqual(DotProduct(new double[] {1, 4, 3}, new double[] {1, 2, 1}), 12);

            Programmeren2Tests.Chapter14Test.TestExercise6(DotProduct);
        }

        public double DotProduct(double[] xs, double[] ys)
        {
            double vector = 0;
            
            for (int i = 0; i < xs.Length; i ++)
            {
                vector += xs[i] * ys[i];
            }

            return vector;
        }


        //7 Write a method AddVectors(u, v) that takes two arrays of doubles of the same length, 
        //and returns a new array containing the sums of the corresponding elements of each:
        [Test]
        public void TestExercise7() 
        {
            double[] v1 = {1, 1};
            double[] v2 = {2, 2};
            double[] v3 = {1, 2};
            double[] v4 = {1, 4};
            double[] v5 = {2, 6};
            double[] v6 = {1, 2, 1};
            double[] v7 = {1, 4, 3};
            double[] v8 = {2, 6, 4};

            Assert.AreEqual(AddVectors(v1, v1), v2);
            Assert.AreEqual(AddVectors(v3, v4), v5);
            Assert.AreEqual(AddVectors(v6, v7), v8);

            Programmeren2Tests.Chapter14Test.TestExercise7(AddVectors);
        }

        public double[] AddVectors(double[] xs, double[] ys) 
        {
            double[] vAnswer = new double[xs.Length];
            for(int i = 0; i < xs.Length; i++)
            {
                vAnswer[i] = xs[i] + ys[i];
            }
            return vAnswer;

        }
        
        //8 Write a method scalarMult(s, v) that takes a number, s, and a array, 
        //v and returns the scalar multiple of v by s:
        [Test]
        public void TestExercise8()
        {
            //Examples of tests
            //Assert.AreEqual(new double[] { 5.5, 11.0 }, Exercise8(5.5, new double[] { 1, 2 }));
            //Assert.AreEqual(new double[] { 3, 0, -9 }, Exercise8(3, new double[] { 1, 0, -3 }));
            //Assert.AreEqual(new double[] { 21, 0, 35, 77, 14 }, Exercise8(7, new double[] { 3, 0, 5, 11, 2 }));

            Programmeren2Tests.Chapter14Test.TestExercise8(Exercise8);
        }

        public double[] Exercise8(double scalar, double[] xs)
        {
            for (int i = 0; i < xs.Length; i++)
            {
                xs[i] = scalar * xs[i];
            }

            return xs;
        }
    }
}
