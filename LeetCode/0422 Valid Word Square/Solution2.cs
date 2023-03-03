using JetBrains.Annotations;

namespace LeetCode._0422_Valid_Word_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/906839305/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
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

                if (words[j].Length < i)
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
