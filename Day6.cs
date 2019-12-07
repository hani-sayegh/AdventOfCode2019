//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//class Solution
//{
//    static void Main(string[] args)
//    {
//        var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");
//        var input = allLines.Select(x => x.Split(')'));

//        var dic = new Dictionary<string, List<string>>();
//        foreach (var n in input)
//        {
//            foreach (var node in n)
//            {
//                if (!dic.ContainsKey(node))
//                {
//                    dic[node] = new List<string>();
//                }
//            }
//                dic[n[0]].Add(n[1]);
//                dic[n[1]].Add(n[0]);
//        }

//        var q = new Queue<(string,int)>();
//        q.Enqueue(("YOU",0));

//        var seen = new HashSet<string>();
//        seen.Add("YOU");
//        while (true)
//        {
//            var (current, dis) = q.Dequeue();
//            if (current == "SAN")
//            {
//                Console.WriteLine(dis - 2);
//                break;
//            }
//            foreach (var child in dic[current])
//            {
//                if (!seen.Contains(child))
//                {
//                    seen.Add(child);
//                    q.Enqueue((child, dis + 1));
//                }
//            }
//        }

//        //var r = dic.Keys.Select(x => Coun(x) - 1).Sum();
//        //Console.WriteLine(r);
//        return;

//        int Coun(string key)
//        {
//            int res = 1;
//            if (!dic.ContainsKey(key))
//                return res;

//            foreach (var child in dic[key])
//            {
//                res += Coun(child);
//            }
//            return res;
//        }
//    }
//}