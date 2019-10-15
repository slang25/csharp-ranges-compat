// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#if NO_RANGES_SUPPORT
using System;

namespace System.Runtime.CompilerServices
{
    public static partial class RuntimeHelpers
    {
        public static int get_IndexerExtension(this int[] array, Index index) =>
            index.IsFromEnd ? array[array.Length - index.Value] : array[index.Value];

        public static int get_IndexerExtension(this Span<int> span, Index index) =>
            index.IsFromEnd ? span[span.Length - index.Value] : span[index.Value];

        public static char get_IndexerExtension(this string s, Index index) =>
            index.IsFromEnd ? s[s.Length - index.Value] : s[index.Value];

        public static Span<int> get_IndexerExtension(this int[] array, Range range) =>
            array.Slice(range);

        public static Span<int> get_IndexerExtension(this Span<int> span, Range range) =>
            span.Slice(range);

        public static string get_IndexerExtension(this string s, Range range) =>
            s.Substring(range);

        public static Span<T> Slice<T>(this T[] array, Range range)
            => array.AsSpan().Slice(range);

        public static Span<T> Slice<T>(this Span<T> span, Range range)
        {
            var (start, length) = GetStartAndLength(range, span.Length);
            return span.Slice(start, length);
        }

        public static string Substring(this string s, Range range)
        {
            var (start, length) = GetStartAndLength(range, s.Length);
            return s.Substring(start, length);
        }

        private static (int start, int length) GetStartAndLength(Range range, int entityLength)
        {
            var start = range.Start.IsFromEnd ? entityLength - range.Start.Value : range.Start.Value;
            var end = range.End.IsFromEnd ? entityLength - range.End.Value : range.End.Value;
            var length = end - start;

            return (start, length);
        }
        
        /// <summary>
        /// Slices the specified array using the specified range.
        /// </summary>
        public static T[] GetSubArray<T>(T[] array, Range range)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            (int offset, int length) = range.GetOffsetAndLength(array.Length);

            if (default(T) != null || typeof(T[]) == array.GetType())
            {
                // We know the type of the array to be exactly T[].

                if (length == 0)
                {
                    return Array.Empty<T>();
                }

                var dest = new T[length];
                Array.Copy(array, offset, dest, 0, length);
                return dest;
            }
            else
            {
                // The array is actually a U[] where U:T.
                T[] dest = (T[])Array.CreateInstance(array.GetType().GetElementType(), length);
                Array.Copy(array, offset, dest, 0, length);
                return dest;
            }
        }
    }
}
#endif