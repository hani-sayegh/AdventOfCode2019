using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int best = -1;
        Solution.NextI(new List<int> { 5, 6, 7, 8, 9 });
        List<int> finalSol = Solution.perms[0];
        foreach (var currentPerm in Solution.perms)
        {
            int secondInput = 0;
            int previousOutput = 0;
            bool completeStp = false;

                var allLines = File.ReadAllLines(@"C:\Users\battlepants\OneDrive\AdventOfCode\input.txt")
                .First()
                .Split(',').Select(int.Parse).ToArray();

            var inputs = new (int[], int)[5];
            for (int i = 0; i != inputs.Length; ++i)
                inputs[i] = (allLines.ToArray(), 0);

            bool outputasinputonly = false;
            for (int currentAmpIdx = 0; ;)
            {
                if (completeStp)
                    break;

                var currentMem = inputs[currentAmpIdx].Item1;
                for (int PC = inputs[currentAmpIdx].Item2; true;)
                {
                    var op = currentMem[PC] % 100;
                    var first = (currentMem[PC] / 100) % 10;
                    var second = (currentMem[PC] / 1000) % 10;
                    var third = (currentMem[PC] / 10000) % 10;

                    //adds
                    if (op == 1)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        var par3 = currentMem[PC + 3];
                        currentMem[par3] = par1 + par2;

                        PC += 4;
                    }

                    //mult
                    if (op == 2)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        var par3 = currentMem[PC + 3];
                        currentMem[par3] = par1 * par2;
                        PC += 4;
                    }

                    if (op == 3)
                    {

                        var input = currentPerm[currentAmpIdx];

                        if (secondInput % 2 == 1)
                        {
                            input = previousOutput;
                        }
                        ++secondInput;

                        if (outputasinputonly)
                            input = previousOutput;

                        currentMem[currentMem[PC + 1]] = input;
                        PC += 2;
                    }

                    //output
                    if (op == 4)
                    {
                        var result = currentMem[currentMem[PC + 1]];

                        if (currentAmpIdx == 4)
                        {
                            best = Math.Max(best, result);
                            outputasinputonly = true;
                        }

                        PC += 2;
                        previousOutput = result;
                        inputs[currentAmpIdx] = (currentMem, PC);

                        ++currentAmpIdx;
                        currentAmpIdx %= 5;
                        break;
                    }

                    if (op == 5)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        if (par1 != 0)
                            PC = par2;
                        else
                            PC += 3;
                    }
                    if (op == 6)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        if (par1 == 0)
                            PC = par2;
                        else
                            PC += 3;
                    }

                    if (op == 7)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        if (par1 < par2)
                            currentMem[currentMem[PC + 3]] = 1;
                        else
                            currentMem[currentMem[PC + 3]] = 0;

                        PC += 4;
                    }
                    if (op == 8)
                    {
                        var par1 = first == 1 ? currentMem[PC + 1] : currentMem[currentMem[PC + 1]];
                        var par2 = second == 1 ? currentMem[PC + 2] : currentMem[currentMem[PC + 2]];
                        if (par1 == par2)
                            currentMem[currentMem[PC + 3]] = 1;
                        else
                            currentMem[currentMem[PC + 3]] = 0;

                        PC += 4;
                    }
                    if (op == 99)
                    {
                        completeStp = true;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(best);
        return;
    }

    static List<List<int>> perms = new List<List<int>>();
    static void NextI(List<int> perm, int start = 0)
    {
        if (start == perm.Count)
            perms.Add(new List<int>(perm));

        for (int i = start; i != perm.Count; ++i)
        {
            var tmp = perm[start];
            perm[start] = perm[i];
            perm[i] = tmp;

            NextI(perm, start + 1);

            tmp = perm[start];
            perm[start] = perm[i];
            perm[i] = tmp;
        }
    }
}