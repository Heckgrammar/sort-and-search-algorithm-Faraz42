using System;
using System.Diagnostics;

namespace compare_algorithm
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            
            Random n = new Random();
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("welcome, how big do you want your array to be");
            int Size = Convert.ToInt32(Console.ReadLine());
            int[] array = CreateArray(Size, n);
            
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            menu(array);
            
        }
        public static int[] CreateArray(int size, Random r)
        {
           int[]  array = new int[size];
            for (int k = 0; k < array.Length; k++)
            {
                array[k] = r.Next(0, 100);
            }
            Console.WriteLine("great! the array has been created using numbers 1 - 100");
            return array;
        }
        static void menu(int[] array)
        {
            Console.WriteLine("using your array, would you like to");
            Console.WriteLine("1) linear search"); // done
            Console.WriteLine("2) binary search"); //
            Console.WriteLine("3) bubble sort"); // done
            Console.WriteLine("4) merge sort"); // done (?)
            Console.WriteLine("5) quit");
            int UserAnswer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(UserAnswer);
            if (UserAnswer == 1)
            {
                Console.WriteLine("and what number would you like to find");
                int NumToFind = Convert.ToInt32(Console.ReadLine());
                LinearSearch(array, NumToFind);
            }
            else if (UserAnswer == 2)
            {
                Console.WriteLine("and what number would you like to find");
                int NumToFind = Convert.ToInt32(Console.ReadLine());
               
                BinarySearch(array, NumToFind);
            }
            else if (UserAnswer == 3)
            {
                BubbleSort(array);
            }
            else if (UserAnswer == 4)
            {
                MergeSortRecursive(array, 0, array.Length - 1);
            }
            else 
            {
                Console.WriteLine("sorry, that option is not valid");
            }
          

        }

        static int[] BubbleSort(int[] a)
        {
            bool swaps;
            int temp;
            do
            {
                swaps = false;
                for (int j = 0; j <= a.Length - 2; j++)
                {
                    if (a[j] > a[j + 1]) 
                    {
                    temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swaps = true;
                    }
                }
            } while (swaps);
            Console.WriteLine($"sorted. Here is the algorithm: ");
            for (int i = 0; i < a.Length; i++) 
            {
                Console.WriteLine(a[i]);
            }
            return a;
        }
        static void Merge(int[] a, int low, int mid, int high)
        {
            int i, j, k;
            int num1 = mid - low + 1;
            int num2 = high - mid;
            int[] L = new int[num1];
            int[] R = new int[num2];
            for (i = 0; i < num1; i++)
            {
                L[i] = a[low + i];
            }
            for (j = 0; j < num2; j++)
            {
                R[j] = a[mid + j + 1];
            }
            i = 0;
            j = 0;
            k = low;
            while (i < num1 && j < num2)
            {
                if (L[i] <= R[j])
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < num1)
            {
                a[k] = L[i];
                i++;
                k++;
            }
            while (j < num2)
            {
                a[k] = R[j];
                j++; k++;
            }
         }
        static void MergeSortRecursive(int[] a, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortRecursive(a, low, mid);
                MergeSortRecursive(a, mid + 1, high);
                Merge(a, low, mid, high);
            }
            
        }
        static bool LinearSearch(int[] a, int numToFind)
        {
            bool found = false;
            do
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == numToFind)
                    {
                        found = true;
                        Console.WriteLine($"is it in the {i + 1} position of the array");
                        return true;
                    }
                    else if (i == a.Length - 1) 
                    {
                        Console.WriteLine($"sorry, {numToFind} is not in the array");
                        break;
                    }

                }
            } while (found == false);
            

            return LinearSearch(a, numToFind);
        }
        static bool BinarySearch(int[] a, int numToFind)
        {
           bool found = false;
            int[] array = BubbleSort(a);
            do
            {
                int midpoint = array.Length / 2 - 1;
                if (midpoint < numToFind)
                {

                }
            } while (found);
            return BinarySearch(a, numToFind);
        }
            
    }
}
