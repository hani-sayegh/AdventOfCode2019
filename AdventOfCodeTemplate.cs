//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Solution
//{
//    static void Main(string[] args)
//    {
//        int solution = -1;
//        var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");
//        var me = allLines.First().Split(',').Select(int.Parse).ToArray();

//        for (int i = 0; i <  me.Length;)
//        {
//            var op = me[i] % 100;
//            var first = (me[i]/100) % 10;
//            var second = (me[i]/1000) % 10;
//            var third = (me[i]/10000) % 10;



//            //adds
//            if (op == 1)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                var par3 = me[i + 3];
//                me[par3] = par1 + par2;

//                i += 4;
//            }

//            //mult
//            if (op == 2)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                var par3 = me[i + 3];
//                me[par3] = par1 * par2;
//                i += 4;
//            }

//            if (op == 3)
//            {
//                me[me[i + 1]] = 5;
//                i += 2;
//            }
//            if (op == 4)
//            {
//                Console.WriteLine(me[me[i + 1]]);
//                i += 2;
//            }

//            if (op == 5)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                if (par1 != 0)
//                    i = par2;
//                else
//                    i += 3;
//            }
//            if (op == 6)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                if (par1 == 0)
//                    i = par2;
//                else
//                    i += 3;
//            }

//            if (op == 7)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                if (par1 < par2)
//                    me[me[i + 3]] = 1;
//                else
//                    me[me[i + 3]] = 0;

//                i += 4;
//            }
//            if (op == 8)
//            {
//                var par1 = first == 1 ? me[i + 1] : me[me[i + 1]];
//                var par2 = second == 1 ? me[i + 2] : me[me[i + 2]];
//                if (par1 == par2)
//                    me[me[i + 3]] = 1;
//                else
//                    me[me[i + 3]] = 0;

//                i += 4;
//            }
//            if (op == 99)
//                break;
//        }
//        solution = me[0];

//        Console.WriteLine();
//    }
//}