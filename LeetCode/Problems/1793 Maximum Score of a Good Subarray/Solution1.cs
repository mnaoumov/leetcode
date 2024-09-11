namespace LeetCode.Problems._1793_Maximum_Score_of_a_Good_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/1080949719/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumScore(int[] nums, int k)
    {
        var minsLeft = new List<(int min, int index)>();
        var minsRight = new List<(int min, int index)>();

        minsLeft.Add((nums[k], k));
        minsRight.Add((nums[k], k));

        for (var i = k + 1; i < nums.Length; i++)
        {
            var lastMin = minsRight[^1].min;
            var num = nums[i];

            if (num >= lastMin)
            {
                minsRight[^1] = (lastMin, i);
            }
            else
            {
                minsRight.Add((num, i));
            }
        }

        for (var i = k - 1; i >= 0; i--)
        {
            var lastMin = minsLeft[^1].min;
            var num = nums[i];

            if (num >= lastMin)
            {
                minsLeft[^1] = (lastMin, i);
            }
            else
            {
                minsLeft.Add((num, i));
            }
        }

        var ans = 0;

        for (var leftIndex = 0; leftIndex < minsLeft.Count; leftIndex++)
        {
            for (var rightIndex = 0; rightIndex < minsRight.Count; rightIndex++)
            {
                var min = Math.Min(minsLeft[leftIndex].min, minsRight[rightIndex].min);
                var i = minsLeft[leftIndex].index;
                var j = minsRight[rightIndex].index;

                ans = Math.Max(ans, min * (j - i + 1));
            }
        }

        return ans;
    }
}
