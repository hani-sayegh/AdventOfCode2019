using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdventOfCode
{
    class Program
    {
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);
        static void Main(string[] args)
        {
            var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt");

           var sol = allLines.Select(int.Parse)
                .Select(x => SumR(x) - x)
                .Sum();


            
            var result = sol;

            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(result.ToString());
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);

            System.Console.WriteLine(result);
            Console.WriteLine();

            int SumR(int init)
            {
                if (init <= 0)
                    return 0;
                return init + SumR(init / 3 - 2);
            }
        }
    }
}
