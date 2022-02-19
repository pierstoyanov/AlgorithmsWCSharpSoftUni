using System;
using System.Linq;

namespace ExamPrep
{
    internal class Socks
    {

        static void Main(string[] args)
        {
            var left = Console.ReadLine().Split().Select(int.Parse).ToArray();
           
            var right = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var dp = new int[left.Length + 1, right.Length + 1];


        }
    }
}
