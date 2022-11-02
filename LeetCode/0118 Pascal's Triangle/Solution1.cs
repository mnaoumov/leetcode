using JetBrains.Annotations;

namespace LeetCode._0118_Pascal_s_Triangle;

/// <summary>
/// https://leetcode.com/submissions/detail/834978870/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new IList<int>[numRows];

        for (var i = 1; i <= numRows; i++)
        {
            var row = new int[i];
            result[i - 1] = row;

            row[0] = 1;

            if (i == 1)
            {
                continue;
            }

            row[^1] = 1;

            var previousRow = result[i - 2];

            for (var j = 1; j < i - 1; j++)
            {
                row[j] = previousRow[j - 1] + previousRow[j];
            }
        }

        return result;
    }
}
