namespace LeetCode.Problems._3866_First_Unique_Even_Element;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-178/problems/first-unique-even-element/submissions/1948015855/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstUniqueEven(int[] nums)
    {
        var uniqueEvens = nums.Where(num => num % 2 == 0).GroupBy(num => num).Where(g => g.Count() == 1).Select(g => g.First())
            .ToHashSet();

        return nums.FirstOrDefault(num => uniqueEvens.Contains(num), -1);
    }
}
