using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence;
            List<BingoBoard> boards;

            (sequence, boards) = ReadData("input.txt");

            bool isBingo = false;
            foreach (var value in sequence)
            {
                foreach (var board in boards)
                {
                    board.Mark(value);
                    if (boards.Count(b => b.IsBingo()== false) == 0)
                    {
                        isBingo = true;
                        Console.WriteLine($"Last Bingo!");
                        board.Print();
                        Console.WriteLine($"{board.CalculateScore()}");
                        break;
                    }
                }
                if (isBingo) break;
            }
        }

        public static void First()
        {
            List<int> sequence;
            List<BingoBoard> boards;

            (sequence, boards) = ReadData("input.txt");

            // foreach (var board in boards)
            // {
            //     board.Print();
            //     Console.WriteLine();
            // }

            bool isBingo = false;
            foreach (var value in sequence)
            {
                foreach (var board in boards)
                {
                    board.Mark(value);
                    if (board.IsBingo())
                    {
                        isBingo = true;
                        Console.WriteLine($"Bingo!");
                        board.Print();
                        Console.WriteLine($"{board.CalculateScore()}");
                        break;
                    }
                }
                if (isBingo) break;
            }
        }

        public static (List<int>, List<BingoBoard>) ReadData(string filename){
            var lines = File.ReadAllLines(filename);
            var sequence = lines[0].Split(',').Select(x => int.Parse(x)).ToList();

            var data = new List<BingoBoard>();
            for(int ii=1 ; ii < lines.Length ; ii+=6)
            {
                var board = new BingoBoard(lines[ii+1], lines[ii+2], lines[ii+3], lines[ii+4], lines[ii+5]) ;
                data.Add(board);
            }

            return (sequence, data);
        }
    }
}
