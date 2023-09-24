using System;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Sorts
{
    internal class Program
    {
        private static void BubbleSort(int[] arr)
        {
            int buffer;
            bool t;
            do
            {
                t = true;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        buffer = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = buffer;
                        t = false;
                    }
                }
            } while (t == false);
        }

        private static void MinSort(int[] arr)
        {
            int buffer, MinIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                MinIndex = arr.Length - 1;
                for (int k = i; k < arr.Length - 1; k++)
                {
                    if (arr[MinIndex] > arr[k]) { MinIndex = k; }
                }
                buffer = arr[i];
                arr[i] = arr[MinIndex];
                arr[MinIndex] = buffer;
            }
        }

        private static void SelectionSort(int[] arr)
        {
            int buffer, MaxIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                MaxIndex = 0;
                for (int k = 1; k < arr.Length - i; k++)
                {
                    if (arr[MaxIndex] < arr[k]) { MaxIndex = k; }
                }
                buffer = arr[arr.Length - i - 1];
                arr[arr.Length - i - 1] = arr[MaxIndex];
                arr[MaxIndex] = buffer;
            }
        }

        private static void InsertionSort(int[] arr)
        {
            int buffer, k;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                k = i;
                while (arr[k] > arr[k + 1])
                {
                    buffer = arr[k];
                    arr[k] = arr[k + 1];
                    arr[k + 1] = buffer;
                    k--;
                    if (k == -1) { break; }
                }
            }
        }

        private static void BinarySort(int[] arr)
        {
            int left, right, mid, buffer;
            for (int i = 1; i < arr.Length; i++)
            {
                buffer = arr[i];
                left = 0;
                right = i - 1;
                while (left <= right)
                {
                    mid = (right + left) / 2;
                    if (buffer < arr[mid]) { right = mid - 1; }
                    else { left = mid + 1; }
                }
                for (int j = i - 1; j >= left; j--) { arr[j + 1] = arr[j]; }
                arr[left] = buffer;
            }
        }

        private static void ShellSort(int[] arr)
        {
            int buffer, range;
            range = arr.Length / 2;
            do
            {
                for (int i = 0; i < arr.Length - range; i++)
                {

                    if (arr[i + range] < arr[i])
                    {
                        buffer = arr[i];
                        arr[i] = arr[i + range];
                        arr[i + range] = buffer;
                    }
                }
                range /= 2;
            } while (range > 0);


            InsertionSort(arr);
        }

        private static void QuickSort(int[] arr, int low = 0, int high = -1)
        {
            if (high == -1) high = arr.Length - 1;
            int temp;
            int i = low;
            int j = high;
            int mid = arr[(i + j) / 2];
            while (i <= j)
            {
                while (arr[i] < mid) i++;
                while (arr[j] > mid) j--;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++; j--;
                }
            }
            if (j > low) QuickSort(arr, low, j);
            if (i < high) QuickSort(arr, i, high);
        }

        private static void ArrFill(int[] arr, int low, int high)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(low, high);
            }
        }
        private static void ArrOutput(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            int Exp, n;
            do
            {
                Console.Write("Число экспериментов: ");
                Exp = Convert.ToInt32(Console.ReadLine());
            } while (Exp < 1 || Exp > 10);
            do
            {
                Console.Write("Число элементов массива: ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n < 1 || n > 10000);

            int[] arr = new int[n];
            int[] arrTmp = new int[n];

            for (int e = 1; e <= Exp; e++)
            {
                ArrFill(arr, 1, 100 + 1);
                arr.CopyTo(arrTmp, 0);
                //Console.WriteLine("\nМассив:");
                //ArrOutput(arr);
                Console.WriteLine($"\nЭксперимент №{e}\n");
                Stopwatch st = new Stopwatch();

                st.Restart();
                BubbleSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки пузырьком: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                MinSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки выбором наименьшего: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                SelectionSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки выбором наибольшего: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                InsertionSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки вставкой: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                BinarySort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки бинарной вставкой: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                ShellSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения сортировки Шелла: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();

                st.Restart();
                QuickSort(arrTmp);
                st.Stop();
                //ArrOutput(arrTmp);
                arr.CopyTo(arrTmp, 0);
                Console.WriteLine($"Время выполнения быстрой сортировки: {st.Elapsed.TotalMilliseconds} мс");
                //Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
