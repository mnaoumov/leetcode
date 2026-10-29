namespace LeetCode.Problems._3514_Number_of_Unique_XOR_Triplets_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-154/problems/number-of-unique-xor-triplets-ii/submissions/1604706166/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int UniqueXorTriplets(int[] nums)
    {
        var xorPairs = new HashSet<int>();

        foreach (var num1 in nums)
        {
            foreach (var num2 in nums)
            {
                xorPairs.Add(num1 ^ num2);
            }
        }

        var xorTriplets = new HashSet<int>();

        foreach (var num in nums)
        {
            foreach (var xorPair in xorPairs)
            {
                xorTriplets.Add(num ^ xorPair);
            }
        }

        return xorTriplets.Count;
    }
}
