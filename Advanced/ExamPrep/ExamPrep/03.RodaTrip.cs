using System.Windows.Markup;

namespace ExamPrep
{
    internal class RodaTrip
    {
        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var spaces = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var maxCap = int.Parse(Console.ReadLine());


            var dp = new int[,]
        }
    }
}