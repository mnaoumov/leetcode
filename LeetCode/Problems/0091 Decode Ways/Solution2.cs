using JetBrains.Annotations;

namespace LeetCode._0091_Decode_Ways;

/// <summary>
/// https://leetcode.com/submissions/detail/828854904/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumDecodings(string s)
    {
        var dp = new int?[s.Length + 2];

        return Get(0);

        int Get(int index)
        {
            if (dp[index] is not { } result)
            {
                dp[index] = result = Calculate();
            }

            return result;

            int Calculate()
            {

                if (index == s.Length)
                {
                    return 1;
                }

                if (index > s.Length)
                {
                    return 0;
                }

                var nextLetterCount = Get(index + 1);
                var afterNextLetterCount = Get(index + 2);
                return s[index] switch
                {
                    '0' => 0,
                    '1' => nextLetterCount + afterNextLetterCount,
                    '2' => nextLetterCount + (index < s.Length - 1 && s[index + 1] <= '6' ? afterNextLetterCount : 0),
                    _ => nextLetterCount
                };
            }
        }
    }
}
