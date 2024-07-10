using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ass_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Q.1.
            twoSum(10, 12);
            // Q.2.
            even1TO100();
            // Q.3.
            isLeapYear(1610);
            // Q.4.
            kmphTOmph(126);
            // Q.5.
            isBuzzNumber(167);
            isBuzzNumber(49);
            // Q.6.
            multiplicationTable();
            // Q.7.
            findFactorial(-5);
            findFactorial(5);
            // Q.8.
            isPrime(37);
            // Q.9.
            typeOfTriangel(12, 13, 14);
            typeOfTriangel(12, 13, 12);
            typeOfTriangel(12, 12, 12);
            // Q.10.
            patternUsingMultiplePrints();
            patternUsingForLoop();
            patternUsingWhileLoop();
            // Bonus Question
            isPalindrom(123211);

        }

        //1.	Write a program that takes two numbers as input and prints their sum
        static void twoSum(int num1, int num2)
        {
            Console.WriteLine($"The sum of {num1} and {num2} is {num1 + num2}");
        }

        //2.	Write a program that prints all the even numbers from 1 to 100
        static void even1TO100()
        {
            int num = 2;
            while (num <= 100)
            {
                Console.WriteLine($"{num} ");
                num = num + 2;
            }
        }

        //3.	Write a function that checks if a given year is leap year or not
        static void isLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                Console.WriteLine($"{year} is leap year");
            }
            else
            {
                Console.WriteLine($"{year} is not leap year");
            }
        }

        //4.	Write a program that converts kilometers per hours to miles per hours.Hint 1km = 0.621371 miles.
        static void kmphTOmph(double kmph)
        {
            double mph = kmph * 0.621371;
            Console.WriteLine($"{kmph}kmph equals to {mph}mph");
        }

        //5.	Write a pseudocode to check whether a number is buzz number or not.Hint a number is said to be if it is divisible by 7 or it end with 7.
        static void isBuzzNumber(int num)
        {
            if (num % 7 == 0 || num % 10 == 7)
            {
                Console.WriteLine($"{num} is a buzz number");
            }
            else
            {
                Console.WriteLine($"{num} is not a buzz number");
            }
        }

        //6.	Write a program that asks user for the number and prints the multiplication table of the number up to 10.
        static void multiplicationTable()
        {
            Console.Write("Enter the number : ");
            string num = Console.ReadLine();
            int orignalNum = int.Parse(num);
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{orignalNum} X {i} = {orignalNum * i}");
            }
        }

        //7.	Write a program that computer the factorial of number(n!).
        static void findFactorial(int num)
        {
            int fac = 1;
            int originalNum = num;
            if (num > 0)
            {
                while (num > 0)
                {
                    fac = fac * num;
                    num--;
                }
            }
            else if (num < 0)
            {
                while (num < 0)
                {
                    fac = fac * num;
                    num++;
                }
            }
            Console.WriteLine($"factorial of {originalNum} is {fac}");
        }

        //8.	Write a program that checks whether a number is prime or not.
        static void isPrime(int num)
        {
            int div = num / 2;
            bool isPrime = true;
            if (num != 2)
            {
                if (num < 2 || num % 2 == 0)
                {
                    isPrime = false;
                }
                else
                {
                    while (div >= 2)
                    {
                        if (num % div == 0)
                        {
                            isPrime = false;
                        }
                        div--;
                    }
                }
            }
            if (isPrime == true)
            {
                Console.WriteLine($"{num} is a prime number");
            }
            else
            {
                Console.WriteLine($"{num} is not a prime number");
            }

        }

        /* 9.	Write a program that checks whether the triangle is equilateral, isosceles or scalene triangle.
                 •	In a Scalene triangle, all sides of a triangle or of different length
                 •	In a Isosceles triangle, two sides of a triangle or of same measure.
                 •	In a Equilateral triangle, all sides of a triangle or of equal length 
        */

        static void typeOfTriangel(int s1, int s2, int s3)
        {
            if (s1 == s2 && s2 == s3)
            {
                Console.WriteLine("Triangle is Equilateral");
            }
            else if (s1 == s2 || s1 == s3 || s2 == s3)
            {
                Console.WriteLine("Triangle is Isosceles");
            }
            else
            {
                Console.WriteLine("Triangle is Scalene");
            }
        }

        /*
                	Pattern Questions:
        10.	Prints this Pattern: (using multiple prints and then by loop).
        *
        **
        ***
        ****
        *****
        */


        // By using multiple prints
        static void patternUsingMultiplePrints()
        {
            Console.WriteLine("By Using multiple Prints");
            Console.WriteLine("*");
            Console.WriteLine("**");
            Console.WriteLine("***");
            Console.WriteLine("****");
            Console.WriteLine("*****");
        }

        //By using for loop

        static void patternUsingForLoop()
        {
            Console.WriteLine("By Using For Loop");
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }


        //By using while loop

        static void patternUsingWhileLoop()
        {
            Console.WriteLine("By Using While Loop");
            int n = 1;
            while (n <= 5)
            {
                int A = 1;
                while (A <= n)
                {
                    Console.Write("*");
                    A++;
                }
                Console.WriteLine();
                n++;
            }
        }

        //11.	Write a function that checks whether the number is palindrom or not
        static void isPalindrom(int num)
        {
            int originalNum = num;
            int rev = 0;
            while (num > 0)
            {
                int rem = num % 10;
                rev = rev * 10 + rem;
                num = num / 10;
            }
            if (rev == originalNum)
            {
                Console.WriteLine($"{originalNum} is palindrom");
            }
            else
            {
                Console.WriteLine($"{originalNum} is not palindrom");
            }
        }

    }
}
