using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataLines = File.ReadAllLines("input.txt");

            long syntaxScore = 0;
            var autocompleteScores = new List<long>();
            int x = 0;

            foreach (var phrase in dataLines)
            {
                var stack = new Stack<char>();
                bool br = false;
                foreach (var mark in phrase.ToList())
                {
                    if (mark == '(' || mark == '[' || mark == '{' || mark == '<')
                    {
                        stack.Push(mark);
                    }
                    else
                    {
                        switch (mark)
                        {
                            case ')':
                                if (stack.Peek() == '(') stack.Pop();
                                else
                                {
                                    Console.WriteLine($"Found {mark} on line {x} while stack has {stack.Peek()}");
                                    syntaxScore += 3;
                                    br = true;
                                }
                                break;
                            case ']':
                                if (stack.Peek() == '[') stack.Pop();
                                else
                                {
                                    Console.WriteLine($"Found {mark} on line {x} while stack has {stack.Peek()}");
                                    syntaxScore += 57;
                                    br = true;
                                }
                                break;
                            case '}':
                                if (stack.Peek() == '{') stack.Pop();
                                else
                                {
                                    Console.WriteLine($"Found {mark} on line {x} while stack has {stack.Peek()}");
                                    syntaxScore += 1197;
                                    br = true;
                                }
                                break;
                            case '>':
                                if (stack.Peek() == '<') stack.Pop();
                                else
                                {
                                    Console.WriteLine($"Found {mark} on line {x} while stack has {stack.Peek()}");
                                    syntaxScore += 25137;
                                    br = true;
                                }
                                break;
                        }
                        if (br) break;
                    }
                }

                if (!br)
                {
                    var missing = string.Empty;
                    long score = 0;
                    while (stack.TryPop(out var result))
                    {
                        switch (result)
                        {
                            case '(':
                                score = score * 5 + 1;
                                missing += ")";
                                break;
                            case '[':
                                score = score * 5 + 2;
                                missing += "]";
                                break;
                            case '{':
                                score = score * 5 + 3;
                                missing += "}";
                                break;
                            case '<':
                                score = score * 5 + 4;
                                missing += ">";
                                break;
                        }
                    }
                    autocompleteScores.Add(score);
                    Console.WriteLine($"Line {x} missing: | {missing} | => Score: {score}");
                }
                x++;
            }

            var autoscore = autocompleteScores.OrderBy(x => x).ToList()[(autocompleteScores.Count/2)];

            syntaxScore.Show("Result: ");
            autoscore.Show("Autocomplete score:");


        }
    }
}
