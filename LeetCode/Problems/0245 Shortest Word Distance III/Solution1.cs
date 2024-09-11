namespace LeetCode.Problems._0245_Shortest_Word_Distance_III;

/// <summary>
/// https://leetcode.com/submissions/detail/926858839/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ShortestWordDistance(string[] wordsDict, string word1, string word2)
    {
        var indices1 = Enumerable.Range(0, wordsDict.Length).Where(index => wordsDict[index] == word1).ToArray();

        if (word1 == word2)
        {
            return Enumerable.Range(0, indices1.Length - 1).Max(index => indices1[index + 1] - indices1[index]);
        }

        var indices2 = Enumerable.Range(0, wordsDict.Length).Where(index => wordsDict[index] == word2).ToArray();

        if (indices1.Length > indices2.Length)
        {
            (indices1, indices2) = (indices2, indices1);
        }

        var result = int.MaxValue;

        foreach (var index1 in indices1)
        {
            var indexOfIndex2 = Array.BinarySearch(indices2, index1);

            if (indexOfIndex2 < 0)
            {
                indexOfIndex2 = ~indexOfIndex2;
            }

            if (indexOfIndex2 < indices2.Length)
            {
                result = Math.Min(result, Math.Abs(index1 - indices2[indexOfIndex2]));
            }

            if (indexOfIndex2 > 0)
            {
                result = Math.Min(result, Math.Abs(index1 - indices2[indexOfIndex2 - 1]));
            }
        }

        return result;
    }
}
