using JetBrains.Annotations;

namespace LeetCode._0126_Word_Ladder_II;

/// <summary>
/// https://leetcode.com/problems/word-ladder-ii/submissions/836473569/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
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

        var result = new List<IList<string>>();

        if (!isEndWordInWordList)
        {
            return result;
        }

        var visited = new HashSet<string>();
        var queue = new Queue<(string word, int sequenceLength, IEnumerable<string> sequence)>();
        queue.Enqueue((beginWord, 0, Enumerable.Empty<string>()));
        var maxSequenceLength = int.MaxValue;

        while (queue.Count > 0)
        {
            var (word, sequenceLength, sequence) = queue.Dequeue();

            if (sequenceLength > maxSequenceLength)
            {
                break;
            }

            if (word == endWord)
            {
                maxSequenceLength = sequenceLength;
                result.Add(sequence.Append(word).ToList());
                continue;
            }

            if (!visited.Add(word))
            {
                continue;
            }

            foreach (var nextWord in transformationDict[word])
            {
                // ReSharper disable once PossibleMultipleEnumeration
                queue.Enqueue((nextWord, sequenceLength + 1, sequence.Append(word)));
            }
        }

        var wordIndexMap = new Dictionary<string, int>();
        var wordTailSequenceMap = new Dictionary<string, List<IEnumerable<string>>>();

        foreach (var list in result)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var word = list[i];

                wordIndexMap[word] = i;

                if (!wordTailSequenceMap.ContainsKey(word))
                {
                    wordTailSequenceMap[word] = new List<IEnumerable<string>>();
                }

                wordTailSequenceMap[word].Add(list.Skip(i));
            }
        }

        visited = new HashSet<string>();
        queue = new Queue<(string word, int sequenceLength, IEnumerable<string> sequence)>();
        queue.Enqueue((beginWord, 0, Enumerable.Empty<string>()));

        while (queue.Count > 0)
        {
            var (word, sequenceLength, sequence) = queue.Dequeue();

            if (sequenceLength > maxSequenceLength)
            {
                break;
            }

            if (word == endWord)
            {
                continue;
            }

            if (!visited.Add(word))
            {
                if (wordIndexMap.TryGetValue(word, out var index) && sequenceLength <= index)
                {
                    result.AddRange(wordTailSequenceMap[word].Select(tailSequence => sequence.Concat(tailSequence).ToList()));
                }

                continue;
            }

            foreach (var nextWord in transformationDict[word])
            {
                // ReSharper disable once PossibleMultipleEnumeration
                queue.Enqueue((nextWord, sequenceLength + 1, sequence.Append(word)));
            }
        }

        return result;
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
