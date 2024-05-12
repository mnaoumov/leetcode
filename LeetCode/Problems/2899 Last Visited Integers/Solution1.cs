using JetBrains.Annotations;

namespace LeetCode.Problems._2899_Last_Visited_Integers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-115/submissions/detail/1075005481/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LastVisitedIntegers(IList<string> words)
    {
        var nums = new List<int>();
        var ans = new List<int>();
        var k = 0;

        foreach (var word in words)
        {
            if (word == "prev")
            {
                k++;

                if (nums.Count >= k)
                {
                    ans.Add(nums[^k]);
                }
                else
                {
                    ans.Add(-1);
                }
            }
            else
            {
                nums.Add(int.Parse(word));
                k = 0;
            }
        }

        return ans;
    }
}
