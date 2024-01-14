using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.calculator.utils
{
    public static class Utils
    {
        public static bool[] Convert(this int value, int size)
        {
            var result = new bool[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = (value & (1 << i)) != 0;
            }

            return result;
        }

        public static int Convert(params bool[] values)
        {
            var result = 0;
            for (var i = 0; i < values.Length; i++)
            {
                result |= values[i] ? 1 << i : 0;
            }

            return result;
        }

        public static string ToColumn(this List<string> list)
        {
            var sb = new StringBuilder();
            list.ForEach(str => sb.Append(str).Append("\n"));
            return sb.ToString();
        }

        public static string ToColumnReversed(this IEnumerable<string> list)
        {
            var sb = new StringBuilder();

            foreach (var str in list.Reverse())
            {
                sb.Append(str).Append("\n");
            }

            return sb.ToString();
        }
    }
}