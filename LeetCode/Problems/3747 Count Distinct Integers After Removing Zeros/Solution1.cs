namespace LeetCode.Problems._3747_Count_Distinct_Integers_After_Removing_Zeros;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-476/problems/count-distinct-integers-after-removing-zeros/submissions/1830874190/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long CountDistinct(long n)
    {
        var str = n.ToString();
        var length = str.Length;

        var powersOf9 = new long[length + 1];
        powersOf9[0] = 1;

        for (var i = 1; i <= length; i++)
        {
            powersOf9[i] = powersOf9[i - 1] * 9;
        }

        var ans = 0L;

        for (var i = 1; i <= length ; i++)
        {
            ans += powersOf9[i];
        }

        for (var i = 0; i < length; i++)
        {
            var digit = str[i] - '0';
            ans -= (9 - digit) * powersOf9[length - 1 - i];
        }

        return ans;
    }
}
