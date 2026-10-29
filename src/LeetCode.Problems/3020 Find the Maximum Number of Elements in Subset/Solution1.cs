namespace LeetCode.Problems._3020_Find_the_Maximum_Number_of_Elements_in_Subset;

/// <summary>
/// https://leetcode.com/problems/find-the-maximum-number-of-elements-in-subset/submissions/2047382042/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumLength(int[] nums)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());

        const int maxNum = 1_000_000_000;
        var maxNumSqrt = (int) Math.Sqrt(maxNum);

        var ans = 1;

        foreach (var num in counts.Keys.OrderBy(x => x))
        {
            if (num == 1)
            {
                continue;
            }

            var length = 1;
            var x = num;

            while (true)
            {
                if (x > maxNumSqrt)
                {
                    break;
                }

                var sqr = x * x;

                if (counts.GetValueOrDefault(x) < 2 || counts.GetValueOrDefault(sqr) < 1)
                {
                    break;
                }

                length += 2;
                x = sqr;
            }

            ans = Math.Max(ans, length);
        }

        return ans;
    }
}
