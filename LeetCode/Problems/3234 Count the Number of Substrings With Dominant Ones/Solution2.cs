namespace LeetCode.Problems._3234_Count_the_Number_of_Substrings_With_Dominant_Ones;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-substrings-with-dominant-ones/submissions/1830460875/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfSubstrings(string s)
    {
        var n = s.Length;
        var lastZeroIndexBefore = new int[n + 1];
        lastZeroIndexBefore[0] = -1;

        for (var i = 0; i < n; i++)
        {
            lastZeroIndexBefore[i + 1] = s[i] == '0' ? i : lastZeroIndexBefore[i];
        }

        var ans = 0;
        var maxPossibleZerosCount = (int) Math.Floor(Math.Sqrt(n));

        for (var r = 0; r < n; r++)
        {
            var zerosCount = s[r] == '0' ? 1 : 0;
            var maxL = r;

            while (maxL >= 0 && zerosCount <= maxPossibleZerosCount)
            {
                var minL = lastZeroIndexBefore[maxL] + 1;

                var maxOnesCount = r - minL + 1 - zerosCount;

                if (zerosCount * zerosCount <= maxOnesCount)
                {
                    ans += Math.Min(maxL - minL + 1, maxOnesCount - zerosCount * zerosCount + 1);
                }

                maxL = minL - 1;
                zerosCount++;
            }
        }

        return ans;
    }
}
