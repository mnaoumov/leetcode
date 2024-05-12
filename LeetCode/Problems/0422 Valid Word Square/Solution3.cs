using JetBrains.Annotations;

namespace LeetCode.Problems._0422_Valid_Word_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/906841538/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public bool ValidWordSquare(IList<string> words)
    {
        var numRows = words.Count;

        for (var i = 0; i < numRows; i++)
        {
            for (var j = i + 1; j < words[i].Length; j++)
            {
                if (j >= numRows)
                {
                    return false;
                }

                if (words[j].Length <= i)
                {
                    return false;
                }

                if (words[i][j] != words[j][i])
                {
                    return false;
                }
            }

            if (words[i].Length < numRows && words[words[i].Length].Length > i)
            {
                return false;
            }
        }

        return true;
    }
}
