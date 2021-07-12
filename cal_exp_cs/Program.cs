using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cal_exp_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDir = Environment.CurrentDirectory;
            string resourcePath = Path.Combine(workingDir, "resource");
            string[] expContent = File.ReadAllLines(Path.Combine(resourcePath, "exp.txt"));
            string[] incomeContent = File.ReadAllLines(Path.Combine(resourcePath, "income.txt"));
            List<int> expenses = new List<int>();
            List<int> income = new List<int>();
            
            Array.ForEach(expContent, delegate(string s) { if (!s.StartsWith("//")) expenses.Add(int.Parse(s.Split("=")[1])); });
            Array.ForEach(incomeContent, delegate(string s) { if(!s.StartsWith("//")) income.Add(int.Parse(s.Split("=")[1])); });

            int sum = expenses.Aggregate((x, y) => x + y);
            int incomeSum = income.Aggregate((x, y) => x + y);
            Console.WriteLine($"Total expenses: {sum}");
            Console.WriteLine($"Total income: {incomeSum}");
            Console.WriteLine($"Balance: { incomeSum - sum }");
        }
    }
}