using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMethods
{
    class Program
    {
        /// <summary>
        ///Recursion is a programming technique, in which a method calls itself to solove
        ///a problem
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("\nDisplay1 method...\n");
            Display1(5);

            Console.WriteLine("\nDisplay2 method...\n");
            Display2(5);

            Console.WriteLine("\nDisplay3 method...\n");
            Display3(5);

            Console.WriteLine("\nDisplayStars1 method...\n");
            DisplayStars1(5);

            Console.WriteLine("\nDisplayStars2 method...\n");
            DisplayStars2(5);

            Console.WriteLine("\nFactorials...\n");
            Factorial(10);

            Console.WriteLine("\nIterative Factorial...Prof's example...\n");
            ProfessorFactorial(10);

            Console.WriteLine("\n\nRecursive Factorial:\n");
            int n;
            Console.Write("enter a positive integer: ");
            int.TryParse(Console.ReadLine(), out n);
            int result = ResultFactorial(n);
            Console.WriteLine("\nResultFactorial({0}) = {1}", n, result);

            Console.WriteLine();
            PyramidStars(10);

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("\n\nArray before recursive inverse: ");
            DisplayArray(array);
            ReverseArray(array, 0, array.Length - 1);
            Console.WriteLine("\n\nArray after recursive inverse: ");
            DisplayArray(array);

            //Testing the interative binary search
            int[] array2 = { 3, 8, 11, 22, 33, 41, 45, 62, 74, 88, 99, 101 };
            Console.WriteLine("\n\nIterative binary search");

            int value = 41;
            int index1 = BinarySearch(array2, 0, array2.Length - 1, value);
            Console.WriteLine("value {0} is at index {1}", value, index1);

            int value2 = 35;
            int index2 = BinarySearch(array2, 0, array2.Length - 1, value2);
            Console.WriteLine("value {0} is at index {1}", value2, index2);

            Console.WriteLine("\n\nRecursive binary search");

            int value3 = 41;
            int index3 = RecursiveBinarySearch(array2, 0, array2.Length - 1, value3);
            Console.WriteLine("value {0} is at index {1}", value3, index3);

            int value4 = 35;
            int index4 = RecursiveBinarySearch(array2, 0, array2.Length - 1, value4);
            Console.WriteLine("value {0} is at index {1}", value4, index4);

            Console.ReadLine();

        }

        //helper method
        static void DisplayArray<T>(T[] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }

        //Display happens before the calls: 5, 4, 3, 2, 1
        static void Display1(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine(n);
            Display1(n - 1);
        }

        //Display happens on the return: 1, 2, 3, 4, 5
        static void Display2(int n)
        {
            if (n == 0)
            {
                return;
            }
            Display2(n - 1);
            Console.WriteLine(n);
        }

        //Display before and after the recursive call
        static void Display3(int n)
        {
            if (n == 0)
            {
                return;
            }
            Console.WriteLine("Before recursive call: {0}", n);
            Display3(n - 1);
            Console.WriteLine(" After recursive call: {0}", n);
        }

        //========================================================
        static void DisplayStars1(int n)
        {
            if (n == 0)
            {
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            DisplayStars1(n - 1);

        }

        static void DisplayStars2(int n)
        {
            if (n == 0)
            {
                return;
            }

            DisplayStars2(n - 1);
            for (int i = 1; i <= n; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();


        }
        static void PyramidStars(int n)
        {
            Console.WriteLine("Enter a height for the pyramid that is less than 100");
            int height = int.Parse(Console.ReadLine());
            int rowLength = (height + 1);
            if (height >= 100)
            {
                Console.WriteLine("Please enter a positive number less than 100.");
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    int numSpaces;
                    int numHash;

                    numSpaces = height - 1 - i;
                    numHash = rowLength - numSpaces;

                    for (int j = 0; j < numSpaces; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < numHash; k++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                }
            }
        }

        static int Factorial(int n)
        {
            int fact = 0;

            if (n > 0)
            {
                int count = 1;
                while (count <= n)
                {
                    if (count == 1)
                    {
                        fact = 1;
                        count++;
                    }
                    else
                    {
                        fact = count * fact;
                        count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Number is not greater than 0");
            }
            Console.WriteLine(fact);
            return fact;
        }

        //second attempt on factorial recursive
        static int ResultFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("invalid negative number");
            }
            if (n == 1 || n == 0)
            {
                return 1;
            }
            int result = n * ResultFactorial(n - 1);
            Console.WriteLine(result);
            return result;

        }

        //iterative approach to factorials 5! = 5*4*3*2*1 = 120
        static int ProfessorFactorial(int n)
        {
            int p = 1;
            for (int x = n; x < 0; x--)
            {
                p *= x;
            }
            Console.WriteLine(p);
            return p;
        }

        //reverse an array using recursion

        static void ReverseArray(int[] array, int first, int last)
        {
            if (first >= last)
            {
                return;
            }

            int temp = array[first];
            array[first] = array[last];
            array[last] = temp;

            ReverseArray(array, first + 1, last - 1);

        }

        //Iterative binary search
        //condition: Array must be sorted
        static int BinarySearch(int[] array, int first, int last, int value)
        {
            //divide and conquer approach
            while (first <= last)
            {
                int mid = (first + last) / 2;
                if (array[mid] == value)
                {
                    return mid;
                }
                if (value > array[mid])
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }
            }
            //if loop runs to completion, it means the value is not found
            return -1;
        }

        static int RecursiveBinarySearch(int[] array, int first, int last, int value)
        {
            if (first > last)
            {
                return -1;
            }
            int mid = (first + last) / 2;
            if (array[mid] == value)
            {
                return mid;
            }
            else if (value > array[mid])
            {
                //include "return" because you return a value
                return RecursiveBinarySearch(array, first = mid + 1, last, value);
            }
            else
            {
                return RecursiveBinarySearch(array, first, last = mid - 1, value);
            }
        }
    }
}
