using System.Collections.Generic;

public static class ListExtras
{
    //    list: List<T> to resize
    //    size: desired new size
    // element: default value to insert

    public static void ResizeList<T>(this List<T> list, int size, T element = default(T))
    {
        int count = list.Count;

        if (size < count)
        {
            for (int i = count; i > size; i--)
            {
                if (list[i] != null)
                    list.RemoveAt(i);
            }
            list.RemoveRange(size, count - size);
        }
        else if (size > count)
        {
            if (size > list.Capacity)   // Optimization
                list.Capacity = size;

            list.AddRange(System.Linq.Enumerable.Repeat(element, size - count));
        }
    }

    public static void InitList<T>(this List<T> list, T element = default(T))
    {
        list.AddRange(System.Linq.Enumerable.Repeat(element, list.Capacity));
    }
}