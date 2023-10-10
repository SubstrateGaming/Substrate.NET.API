using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Extensions
{
    public static class ArrayExtension
    {
        public static T[] SubArray<T>(this T[] array, int start, int end)
        {
            int length = end - start;
            if(length < 0)
                throw new InvalidOperationException($"{nameof(SubArray)} has start invalid start / end");

            T[] result = new T[length];
            Array.Copy(array, start, result, 0, length);
            return result;
        }

        public static T[] SubArray<T>(this T[] array, int start) => SubArray(array, start, array.Length);
    }
}
