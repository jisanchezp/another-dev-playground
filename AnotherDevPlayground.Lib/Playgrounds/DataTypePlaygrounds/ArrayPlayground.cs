using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds
{   
    internal static class ArrayPlayground
    {
        /*
         
        Array properties:

        - Arrays con be single-dimensional, multidimensional, or jagged.
        - The number of dimensions are set when an array variable is declared.
          The length of each dimension is established when the array instance is created.
          These values can't be changed during the lifetime of the instance.
        - A jagged array is an array of arrays, and each member array has the default value
          of null.
        - Array are zero indexed: an array with n elements is indexed from 0 to n-1.
        - Array elements can be of any type, including an array type.
        - Array types are reference types derived from the abstract base type Array.
          All arrays implement IList and IEnumerable. You can use the foreach statement
          to iterate through an array. Single'dimensional arrays also implement IList<T>
          and IEnumerable<T>.
          
        */

        public static void ArrayInAllDimensions() 
        {
            // Declare a single-dimensional array of 5 integers.
            int[] array1 = new int[10]; // Elements are zero initialized
            string[] array1b = new string[5]; // Elements are null initialized

            // Declare and set array element values.
            int[] array2 = [1, 2, 3, 4, 5, 6]; // Collection expression sintax. C# 12+ (.NET 8).
            int[] array3 = { 1, 2, 3, 4, 5, 6 }; // Alternative sintax .NET 7 and below.

            // Declare a two multi dimensional array.
            int[,] multidimensionalArray1 = new int[2, 3];

            // Declare and set array element values.
            int[,] multidimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];
            int[][] jaggedArray2 = new int[6][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = [1, 2, 3, 4];

            jaggedArray2[0] = array1;
            jaggedArray2[1] = array2;
        }

        private static void DisplayArray(string[] arr) => Console.WriteLine(string.Join(", ", arr));
        private static void ChangeArray(string[] arr) => Array.Reverse(arr);

        private static void ChangeArrayElements(string[] arr) 
        {
            arr[0] = "Mon";
            arr[1] = "Wed";
            arr[2] = "Fri";
        }

        public static void PassSingleDimensionalArraysAsArguments()
        {
            string[] weekDays = ["Sun", "Monday", "Tue", "Wed", "Thu", "Fri", "Sat"];
            DisplayArray(weekDays);
            Console.WriteLine();

            ChangeArray(weekDays);

            Console.WriteLine("Array weekDays after the call to ChangeArray: ");
            DisplayArray(weekDays);
            Console.WriteLine();

            ChangeArrayElements(weekDays);
            Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
            DisplayArray(weekDays);

        }

        public static void PrintCollection<T>(this T array) where T : ICollection
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
    }
}
