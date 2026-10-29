namespace LeetCode.Problems._1945_Sum_of_Digits_of_String_After_Convert;

/// <summary>
/// https://leetcode.com/submissions/detail/1377133769/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetLucky(string s, int k)
    {
        var ans = s.Select(letter => letter - 'a' + 1).SelectMany(GetDigits).Sum();
        for (var i = 1; i < k; i++)
        {
            ans = GetDigits(ans).Sum();
        }

        return ans;
    }

    private static IEnumerable<int> GetDigits(int n)
    {
        while (n > 0)
        {
            yield return n % 10;
            n /= 10;
        }
    }
}
