namespace LeetCode.Problems._0126_Word_Ladder_II;

/// <summary>
/// https://leetcode.com/problems/word-ladder-ii/submissions/836520763/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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

        var visited = new Dictionary<string, int>();
        var queue = new Queue<(string word, int sequenceLength, IEnumerable<string> sequence)>();
        queue.Enqueue((beginWord, 0, Enumerable.Empty<string>()));
        var maxSequenceLength = int.MaxValue;
        var prefixesMap = new Dictionary<string, List<IEnumerable<string>>>();

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

            if (!visited.TryAdd(word, sequenceLength))
            {
                if (visited[word] < sequenceLength)
                {
                    continue;
                }

                // ReSharper disable once UseCollectionExpression
                prefixesMap.TryAdd(word, new List<IEnumerable<string>>());
                prefixesMap[word].Add(sequence);
                continue;
            }

            foreach (var nextWord in transformationDict[word])
            {
                // ReSharper disable once PossibleMultipleEnumeration
                queue.Enqueue((nextWord, sequenceLength + 1, sequence.Append(word)));
            }
        }

        for (var index = 0; index < result.Count; index++)
        {
            var list = result.ToArray()[index];

            for (var i = 0; i < list.Count; i++)
            {
                var word = list[i];
                result.AddRange(prefixesMap.GetValueOrDefault(word, new List<IEnumerable<string>>())
                    .Select(prefix => prefix.Concat(list.Skip(i)).ToList()));
                prefixesMap.Remove(word);
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
