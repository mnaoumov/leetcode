using System.Text;

namespace LeetCode.Problems._3474_Lexicographically_Smallest_Generated_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-439/problems/lexicographically-smallest-generated-string/submissions/1559949124/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution4 : ISolution
{
    public string GenerateString(string str1, string str2)
    {
        var n = str1.Length;
        var m = str2.Length;
        var sb = new StringBuilder();
        const char unset = '.';
        const char shouldBeEqual = 'T';
        const char shouldBeNotEqual = 'F';
        const string impossible = "";
        sb.Append(unset, n + m - 1);
        var unsetIndices = new SortedSet<int>(Enumerable.Range(0, sb.Length));
        var shouldBeNotEqualIndices = new SortedSet<int>();

        for (var i = 0; i < n; i++)
        {
            if (str1[i] != shouldBeEqual)
            {
                continue;
            }

            for (var j = 0; j < m; j++)
            {
                if (sb[i + j] == unset)
                {
                    sb[i + j] = str2[j];
                    unsetIndices.Remove(i + j);
                }
                else if (sb[i + j] != str2[j])
                {
                    return impossible;
                }
            }
        }

        for (var i = 0; i < n; i++)
        {
            if (str1[i] != shouldBeNotEqual)
            {
                continue;
            }

            var isEqual = true;
            var isPossiblyEqual = true;
            for (var j = 0; j < m; j++)
            {
                if (sb[i + j] == unset)
                {
                    isEqual = false;
                    continue;
                }

                if (sb[i + j] == str2[j])
                {
                    continue;
                }

                isEqual = false;
                isPossiblyEqual = false;
                break;
            }

            if (isEqual)
            {
                return impossible;
            }

            if (isPossiblyEqual)
            {
                shouldBeNotEqualIndices.Add(i);
            }
        }

        foreach (var unsetIndex in unsetIndices.ToArray())
        {
            var shouldBeNotEqualIndicesFiltered = shouldBeNotEqualIndices.GetViewBetween(unsetIndex - m + 1, unsetIndex).ToArray();

            var impossibleValues = new HashSet<char>();

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var shouldBeNotEqualIndex in shouldBeNotEqualIndicesFiltered)
            {
                var unsetIndicesCount = unsetIndices.GetViewBetween(shouldBeNotEqualIndex, shouldBeNotEqualIndex + m - 1).Count;

                if (unsetIndicesCount == 1)
                {
                    impossibleValues.Add(str2[unsetIndex - shouldBeNotEqualIndex]);
                }
            }

            for (var possibleChar = 'a'; possibleChar <= 'z'; possibleChar++)
            {
                if (impossibleValues.Contains(possibleChar))
                {
                    continue;
                }

                sb[unsetIndex] = possibleChar;
                unsetIndices.Remove(unsetIndex);

                foreach (var shouldBeNotEqualIndex in shouldBeNotEqualIndicesFiltered)
                {
                    if (str2[unsetIndex - shouldBeNotEqualIndex] != possibleChar)
                    {
                        shouldBeNotEqualIndices.Remove(shouldBeNotEqualIndex);
                    }
                }

                break;
            }

            if (unsetIndices.Contains(unsetIndex))
            {
                return impossible;
            }
        }

        return sb.ToString();
    }
}
