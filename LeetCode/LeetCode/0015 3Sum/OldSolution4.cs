namespace LeetCode._0015_3Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/200381265/
/// </summary>
public class OldSolution4 : ISolution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var numsSet = new HashSet<int>(nums);

        var results = new List<IList<int>>();

        var n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (i + 2 < n && nums[i] == nums[i + 2])
            {
                continue;
            }

            for (int j = i + 1; j < n; j++)
            {
                if (j > i + 1 && nums[i] == nums[i + 1])
                {
                    break;
                }

                if (j + 1 < n && nums[j] == nums[j + 1])
                {
                    continue;
                }

                var first = nums[i];
                var second = nums[j];
                var third = -(first + second);

                if (third < second)
                {
                    continue;
                }

                if (!numsSet.Contains(third))
                {
                    continue;
                }

                bool isDuplicate = false;

                if (third == second)
                {
                    if (third == first)
                    {
                        isDuplicate = i == 0 || nums[i] != nums[i - 1];
                    }
                    else
                    {
                        isDuplicate = nums[j] != nums[j - 1];
                    }
                }

                if (!isDuplicate)
                {
                    results.Add(new[] { first, second, third });
                }
            }
        }

        return results;
    }
}