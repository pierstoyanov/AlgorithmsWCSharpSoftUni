using System;
using System.Collections.Generic;
using System.Linq;

class WordCruncher
{
    private static string target;
    private static Dictionary<int, List<string>> wordsByIdx;
    private static Dictionary<string, int> wordsCount;
    private static LinkedList<string> usedWords;
    
    public static void Main(string[] args)
    {
        var words = Console.ReadLine().Split(", ");
        target = Console.ReadLine();

        wordsByIdx = new Dictionary<int, List<string>>();
        wordsCount = new Dictionary<string, int>();
        usedWords = new LinkedList<string>();

        foreach (var item in words)
        {
            var idx = target.IndexOf(item);

            if (idx == -1)
            {
                continue;
            }

            if (wordsCount.ContainsKey(item))
            {
                wordsCount[item]++;
                continue;
            }

            wordsCount[item] = 1;

            while(idx != -1)
            {
                if (!wordsByIdx.ContainsKey(idx))
                {
                      wordsByIdx.Add(idx, new List<string>());
                }
                wordsByIdx[idx].Add(item);

                idx = target.IndexOf(item, idx + 1);
            }
        }

        GenSolutions(0);
    }

    private static void GenSolutions(int idx)
    {
        if (idx == target.Length)
        {
            Console.WriteLine(string.Join(" ", usedWords));
            return;
        }

        if (!wordsByIdx.ContainsKey(idx))
        {
            return;
        }

        foreach (var word in wordsByIdx[idx]) 
        {

            if (wordsCount[word] == 0)
            {
                continue;
            }


            wordsCount[word] -= 1;
            usedWords.AddLast(word);

            GenSolutions(idx + word.Length);

            wordsCount[word] += 1;
            usedWords.RemoveLast();
        }
    }
}

