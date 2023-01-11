using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb13_Brackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            var result = BracketsGenerator.Generate(10);
            Console.WriteLine(result);
            Console.WriteLine($"Всего скобок: {result.Length}");
            Console.WriteLine($"( = {result.Count(c => c=='(')}");
            Console.WriteLine($") = {result.Count(c => c == ')')}");
            Console.ReadLine();
        }
    }

    public static class BracketsGenerator
    {
        public static string Generate(int count)
        {
            var str = "";
            Generate(count, ref str);
            return str;
        }

        private static string Generate(int count, ref string str, bool isSealed = false)
        {
            str += '(';
            isSealed = isSealed || count < 0;
            if(!isSealed)
                Generate(count-2, ref str);
            str+=')';
            return str;
        }
    }
}
