using System;

namespace _4 {
    public class BingoEntry{
        public BingoEntry(int row, int column, string value)
        {
            Row = row;
            Column = column;
            Value = int.Parse(value);
            Called = false;
        }

         public int Column { get; set; }
         public int Row { get; set; }
         public int Value { get; set; }
         public bool Called { get; set; }
         public void Mark() => Called = true;
    }
}