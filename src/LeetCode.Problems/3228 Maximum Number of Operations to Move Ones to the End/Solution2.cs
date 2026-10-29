namespace LeetCode.Problems._3228_Maximum_Number_of_Operations_to_Move_Ones_to_the_End;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-407/submissions/detail/1327968970/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxOperations(string s)
    {
        var n = s.Length;
        var ans = 0;

        var oneIndices = Enumerable.Range(0, n).Where(i => s[i] == '1').ToArray();
        var m = oneIndices.Length;

        var i = 0;

        while (i < m)
        {
            var oneIndex = oneIndices[i];

            if (oneIndex == n - 1)
            {
                break;
            }

            if (i == m - 1)
            {
                ans++;
                oneIndices[i] = n - 1;
                i = i == 0 ? 1 : i - 1;
            }
            else if (oneIndices[i + 1] != oneIndex + 1)
            {
                ans++;
                oneIndices[i] = oneIndices[i + 1] - 1;
                i = i == 0 ? 1 : i - 1;
            }
            else
            {
                i++;
            }
        }

        return ans;
    }
}
