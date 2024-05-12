using JetBrains.Annotations;

namespace LeetCode._0127_Word_Ladder;

/// <summary>
/// https://leetcode.com/problems/word-ladder/submissions/836525602/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        var transformationDict = new Dictionary<string, HashSet<string>>();
        var isEndWordInWordList = false;

        foreach (var word in wordList.Append(beginWord))
        {
            transformationDict[word] = new HashSet<string>();
        }

        for (var i = 0; i < wordList.Count; i++)
        {
            if (wordList[i] == endWord)
            {
                isEndWordInWordList = true;
            }

            if (CanTransform(beginWord, wordList[i]))
            {
                transformationDict[beginWord].Add(wordList[i]);
            }

            for (var j = i + 1; j < wordList.Count; j++)
            {
                if (!CanTransform(wordList[i], wordList[j]))
                {
                    continue;
                }

                transformationDict[wordList[i]].Add(wordList[j]);
                transformationDict[wordList[j]].Add(wordList[i]);
            }
        }

        if (!isEndWordInWordList)
        {
            return 0;
        }

        var visited = new HashSet<string>();
        var queue = new Queue<(string word, int sequenceLength)>();
        queue.Enqueue((beginWord, 1));

        while (queue.Count > 0)
        {
            var (word, sequenceLength) = queue.Dequeue();

            if (word == endWord)
            {
                return sequenceLength;
            }

            if (!visited.Add(word))
            {
                continue;
            }

            foreach (var nextWord in transformationDict[word])
            {
                queue.Enqueue((nextWord, sequenceLength + 1));
            }
        }

        return 0;
    }

    private static bool CanTransform(string word1, string word2)
    {
        var hasDiff = false;
        for (var i = 0; i < word1.Length; i++)
        {
            if (word1[i] == word2[i])
            {
                continue;
            }

            if (hasDiff)
            {
                return false;
            }

            hasDiff = true;
        }

        return hasDiff;
    }

}
