using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _16
{
    class Program
    {
        static void Main(string[] args)
        {
            var codeHex = File.ReadAllText("input.txt");

            StringBuilder sb = new StringBuilder();
            foreach(var hex in codeHex.ToList())
            {
                var binary = Convert.ToString(Convert.ToInt16(hex.ToString(), 16), 2).PadLeft(4, '0');
                sb.Append(binary);
            }

            var code = sb.ToString();
            var packet = new Packet(code);

            // Console.WriteLine($"{sb.ToString()}");
            // Console.WriteLine($"Version: {packet.Version}; TypeId: {packet.TypeId}; Literal: {packet.Literal}");

            packet.GetPacketVersionSum().Show("Result: ");
            packet.GetValue().Show("Value: ");
        }
    }
}
