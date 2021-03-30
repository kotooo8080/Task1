using System;

namespace Task1
{
    public class SortByInserts<T> where T : IComparable<T>
    {
        public static void inDirectOrder(T[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                T val = arr[i];
                int index = i;
                while ((index > 0) && (arr[index - 1].CompareTo(val) > 0)) {
                    arr[index] = arr[index - 1];
                    --index;
                }
                arr[index] = val;
            }
        }

        public static void inReverseOrder(T[] arr)
        {
            for (int i = 1; i < arr.Length; ++i)
            {
                T val = arr[i];
                int index = i;
                while ((index > 0) && (arr[index - 1].CompareTo(val) < 0)) {
                    arr[index] = arr[index - 1];
                    --index;
                }
                arr[index] = val;
            }
        }
    }
}
