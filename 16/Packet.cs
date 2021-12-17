using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _16
{
    public class Packet
    {
        public const int TYPE_LITERAL = 4;

        public int Version { get; private set; }
        public int TypeId { get; private set; }
        public long Literal { get; private set; }
        public int Length { get; private set; }
        private int LengthTypeId { get; set; }
        private int subpacketCount { get; set; }
        private int subpacketLength { get; set; }

        public int Depth { get; set; }
        public List<Packet> SubPackets { get; set; }
        public Packet(string binaryCode, int depth = 0)
        {
            Depth = depth;
            Version = binaryCode.ReadBinaryNumber(0, 3);
            TypeId = binaryCode.ReadBinaryNumber(3, 3);
            Length = 6;

            if (TypeId == TYPE_LITERAL)
            {
                var literal_size = ExtractLiteral(binaryCode.Substring(6));
                Length += literal_size;

                Print();
                return;
            }

            LengthTypeId = binaryCode.ReadBinaryNumber(6, 1);
            Length += 1;

            SubPackets = new List<Packet>();

            //Print();

            if (LengthTypeId == 0)
            {
                subpacketLength = binaryCode.ReadBinaryNumber(7, 15);
                Length += 15;

                Print();

                var currentSubpacketLength = 0;
                do
                {
                    var subpacket = new Packet(binaryCode.Substring(22 + currentSubpacketLength), Depth + 1);
                    SubPackets.Add(subpacket);
                    currentSubpacketLength += subpacket.Length;

                    //subpacket.Literal.Show($"Literal {SubPackets.Count}");
                }
                while (currentSubpacketLength < subpacketLength);

                Length += subpacketLength;

                return;
            }

            // LengthTypeId == 1
            {
                subpacketCount = binaryCode.ReadBinaryNumber(7, 11);
                Length += 11;
                Print();
                var currentSubpacketLength = 0;
                for (int i = 0; i < subpacketCount; i++)
                {
                    var subpacket = new Packet(binaryCode.Substring(18 + currentSubpacketLength), Depth + 1);
                    SubPackets.Add(subpacket);
                    currentSubpacketLength += subpacket.Length;
                    //subpacket.Literal.Show($"Literal {SubPackets.Count}");
                }
                Length += currentSubpacketLength;

                return;
            }
        }

        private int ExtractLiteral(string binaryCode)
        {
            int current = 0;
            var sb = new StringBuilder();
            bool cont;
            do
            {
                cont = binaryCode.Substring(current, 1) == "1";
                var number = binaryCode.Substring(current + 1, 4);
                sb.Append(number);
                current += 5;
            } while (cont);

            Literal = Convert.ToInt64(sb.ToString(), 2);

            return current;
        }

        public int GetPacketVersionSum()
        {
            var sum = Version;

            if (SubPackets != null)
                sum += SubPackets.Sum(sp => sp.GetPacketVersionSum());

            return sum;
        }

        public long GetValue()
        {
            switch (TypeId)
            {
                case 0: // Sum
                    return SubPackets.Sum(sp => sp.GetValue());

                case 1: // Product
                    return SubPackets
                        .Select(sp => sp.GetValue())
                        .Aggregate<long, long>(1, (acc, val) => acc * val);

                case 2: // Minimum
                    return SubPackets.Min(sp => sp.GetValue());

                case 3: // Maximum
                    return SubPackets.Max(sp => sp.GetValue());

                case 4: // Literal
                    return Literal;

                case 5: // Greater than
                    return SubPackets[0].GetValue() > SubPackets[1].GetValue() ? 1 : 0;

                case 6: // Less than
                    return SubPackets[0].GetValue() < SubPackets[1].GetValue() ? 1 : 0;

                case 7: // equal
                    return SubPackets[0].GetValue() == SubPackets[1].GetValue() ? 1 : 0;
                default:
                    throw new Exception();
            }
        }

        public void PrintDepth()
        {
            for (int i = 0; i < Depth; i++)
            {
                Console.Write(" ");
            }
        }

        public void Print()
        {
            PrintDepth();
            if (TypeId == TYPE_LITERAL)
            {
                Console.WriteLine($"L:{Literal}; Len:{Length}");
            }
            else
            {
                if (LengthTypeId == 0)
                {
                    Console.WriteLine($"T:{TypeId}; V:{Version}; SL:{subpacketLength}");
                }
                else
                {
                    Console.WriteLine($"T:{TypeId}; V:{Version}; SC:{subpacketCount}");
                }
            }
        }

    }
}