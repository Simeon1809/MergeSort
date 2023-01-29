using System;

namespace MergeSort
{
    class Program
    {   
        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            if (array.Length <= 1)
            {
                return array;
            }

            int midPoint = array.Length / 2;
            left = new int[midPoint];

            if (array.Length % 2 == 0)
            {
                right = new int[midPoint];
            }
            else
            {
                right = new int[midPoint + 1];
            }
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }

            int x = 0;
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }
        public static void PrintSorted(int[] array)
        {
            int[] sorted = mergeSort(array);

            int[] unsorted = array;
            Console.WriteLine("The unsorted arrays are: ");
            for (int i = 0; i < unsorted.Length; i++)
            {
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("The sorted arrays are: ");
                for (int i = 0; i < sorted.Length; i++)
                {
                Console.Write( sorted[i]+ " ");
                }
                Console.WriteLine("\n"); 
        }

        static void Main(string[] arg)
        {
            int[] array =new int[] {96, 10, 4, 9, 34, 16, 80, 6, 1, 65, 15 };
            PrintSorted(array);
        }
    }
}
