using System;
using System.Linq;
using System.Collections.Generic;

namespace _3 
{
    public static class BinaryRowExtensions 
    {
        public static int ToInteger(this int[] binaryTable) => Convert.ToInt32(binaryTable.ToDisplayString(), 2);
        public static string ToDisplayString(this int[] binaryTable) => string.Join("", binaryTable.Select(x => x.ToString()));
    
        public static List<int[]> FilterOnColumn(this List<int[]> data, int columnNumber, int value) => data.Where(entry => entry[columnNumber] == value).ToList();
    }
}