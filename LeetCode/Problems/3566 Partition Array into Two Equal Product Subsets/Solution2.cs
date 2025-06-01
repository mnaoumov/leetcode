namespace LeetCode.Problems._3566_Partition_Array_into_Two_Equal_Product_Subsets;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-452/problems/partition-array-into-two-equal-product-subsets/submissions/1650246072/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool CheckEqualPartitions(int[] nums, long target)
    {
        var totalProduct = nums.Aggregate(1L, (prod, num) => prod * num);
        if (target * target != totalProduct)
        {
            return false;
        }

        long runningProduct = nums[0];
        return AddProduct(1);

        bool AddProduct(int index)
        {
            if (runningProduct == target)
            {
                return true;
            }

            if (index >= nums.Length || runningProduct > target)
            {
                return false;
            }

            runningProduct *= nums[index];
            if (AddProduct(index + 1))
            {
                return true;
            }
            runningProduct /= nums[index];
            // ReSharper disable once TailRecursiveCall
            return AddProduct(index + 1);
        }
    }
}
