using System;
using System.Collections.Generic;
using System.Linq;

namespace _4 {
    public class BingoBoard
    {
        List<BingoEntry> _board;
        bool _isBingo = false;
        int winningNumber;
        public BingoBoard(string r1, string r2, string r3, string r4, string r5)
        {
            _board = new List<BingoEntry>();
            _board.AddRange(Enumerable.Range(0,5).Select(column => new BingoEntry(0, column, r1.Substring(column*3,2))));
            _board.AddRange(Enumerable.Range(0,5).Select(column => new BingoEntry(1, column, r2.Substring(column*3,2))));
            _board.AddRange(Enumerable.Range(0,5).Select(column => new BingoEntry(2, column, r3.Substring(column*3,2))));
            _board.AddRange(Enumerable.Range(0,5).Select(column => new BingoEntry(3, column, r4.Substring(column*3,2))));
            _board.AddRange(Enumerable.Range(0,5).Select(column => new BingoEntry(4, column, r5.Substring(column*3,2))));
        }

        public void Mark(int value)
        {
            var entry = _board.SingleOrDefault(entry => entry.Value == value);
            if (entry != null)
            {
                entry.Mark();

                // Check column
                if (_board.Where(e => e.Column == entry.Column).All(e => e.Called == true))
                {
                    _isBingo = true;
                    winningNumber = value;
                }
                // Check row
                if (_board.Where(e => e.Row == entry.Row).All(e => e.Called == true))
                {
                    _isBingo = true;
                    winningNumber = value;
                }
            }
        }
        public bool IsBingo() => _isBingo;

        public void Print()
        {
            for (int i = 0; i < 5; i++) { 
                foreach (var entry in _board.Where(x=> x.Row == i).OrderBy(x=> x.Column))
                {
                    var mark = entry.Called ? "*" : "";
                    Console.Write($"{entry.Value}{mark} ");
                }
                Console.WriteLine();
            }
        }

        public int CalculateScore()
        {
            return _board.Where(e => e.Called == false).Sum(e => e.Value) * winningNumber;
        }
    }
}