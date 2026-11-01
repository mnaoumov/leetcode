namespace LeetCode.Problems._1518_Water_Bottles;

/// <seealso href="https://leetcode.com/submissions/detail/1312202718/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        var ans = numBottles;
        var emptyBottlesCount = numBottles;

        while (emptyBottlesCount >= numExchange)
        {
            var newBottlesCount = emptyBottlesCount / numExchange;
            emptyBottlesCount -= newBottlesCount * numExchange;
            ans += newBottlesCount;
            emptyBottlesCount += newBottlesCount;
        }

        return ans;
    }
}
