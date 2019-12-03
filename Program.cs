using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    class ClipBoard
    {
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);

        public static void Set(string s)
        {
            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(s);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }

    //class Day1
    //{
    //    static void Main(string[] args)
    //    {
    //        var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");

    //        var sol = allLines.Select(int.Parse)
    //             .Aggregate(0, (sum, current) => sum += SumR(current) - current);


    //        var result = sol;

    //        ClipBoard.Set(result.ToString());
    //        System.Console.WriteLine(result);
    //        Console.WriteLine();

    //        int SumR(int init)
    //        {
    //            if (init <= 0)
    //                return 0;
    //            return init + SumR(init / 3 - 2);
    //        }
    //    }
    //}

    //class Day2
    //{
    //    static void Main(string[] args)
    //    {

    //        int solution = -1;
    //        var tar = 19690720;
    //        for (int x = 0; x != 100; ++x)
    //            for (int y = 0; y != 100; ++y)
    //            {
    //        var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");
    //        var me = allLines.First().Split(',').Select(int.Parse).ToArray();

    //                me[1] = x;
    //                me[2] = y;
    //                for (int i = 0; i != me.Length;)
    //                {
    //                    if (me[i] == 1)
    //                    {
    //                        me[me[i + 3]] = me[me[i + 1]] + me[me[i + 2]];
    //                        i += 4;
    //                    }
    //                    if (me[i] == 2)
    //                    {
    //                        me[me[i + 3]] = me[me[i + 1]] * me[me[i + 2]];
    //                        i += 4;
    //                    }

    //                    if (me[i] == 99)
    //                        break;
    //                }
    //                solution = me[0];
    //                if (solution == tar)
    //                    break;
    //            }


    //        var result = solution;
    //        ClipBoard.Set(result.ToString());
    //        Console.WriteLine(result);
    //        Console.WriteLine();
    //    }
    //}

    class Day3
    {
        static void Main(string[] args)
        {

            var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");
            var me = allLines.First().Split(',').Select(int.Parse).ToArray();

            ClipBoard.Set(result.ToString());
            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
