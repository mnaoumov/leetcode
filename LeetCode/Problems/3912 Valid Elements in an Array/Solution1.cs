namespace LeetCode.Problems._3912_Valid_Elements_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-499/problems/valid-elements-in-an-array/submissions/1988214817/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> FindValidElements(int[] nums)
    {
        var ans = new List<int>();

        var n = nums.Length;

        var maxesToTheRight = new int[n];
        maxesToTheRight[^1] = int.MinValue;

        for (var i = n - 2; i >= 0; i--)
        {
            maxesToTheRight[i] = Math.Max(maxesToTheRight[i + 1], nums[i + 1]);
        }

        var maxToTheLeft = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (num > maxToTheLeft || num > maxesToTheRight[i])
            {
                ans.Add(num);
            }

            maxToTheLeft = Math.Max(num, maxToTheLeft);
        }

        return ans;
    }
}
