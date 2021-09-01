﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PassTrueOrNotNum(File.ReadAllLines("source.txt")));
            Console.WriteLine(PassTrueOrNotIndex(File.ReadAllLines("source.txt")));
        }

        static int PassTrueOrNotNum(IEnumerable<string> list)
        {
            int goodPass = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                List<string> split = list.ElementAt(i).Split(':').ToList();
                split = new List<string>() { split[0].Split('-').ToList()[0], split[0].Split('-')[1].Split(' ')[0], split[0].Split(' ')[1], split[1] };
                int min = int.Parse(split[0]);
                int max = int.Parse(split[1]);
                char must = char.Parse(split[2]);

                int goodLetter = 0;

                for (int j = 0; j < split[3].Length; j++)
                {
                    if (split[3][j] == must)
                    {
                        goodLetter++;
                    }
                }

                if (goodLetter >= min && goodLetter <= max)
                {
                    goodPass++;
                }
            }
            return goodPass;
        }

        static int PassTrueOrNotIndex(IEnumerable<string> list)
        {
            int goodPass = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                List<string> split = list.ElementAt(i).Split(':').ToList();
                split = new List<string>() { split[0].Split('-').ToList()[0], split[0].Split('-')[1].Split(' ')[0], split[0].Split(' ')[1], split[1] };
                int firstInd = int.Parse(split[0]);
                int secondInd = int.Parse(split[1]);
                char must = char.Parse(split[2]);

                if (split[3][firstInd] == must ^ split[3][secondInd] == must)
                {
                    goodPass++;
                }
            }
            return goodPass;
        }
    }
}
