namespace LeetCode.Problems._1726_Tuple_with_Same_Product;

/// <summary>
/// https://leetcode.com/problems/tuple-with-same-product/submissions/1533004051/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TupleSameProduct(int[] nums)
    {
        var productCounts = new Dictionary<int, int>();

        var n = nums.Length;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                var product = nums[i] * nums[j];
                productCounts.TryAdd(product, 0);
                productCounts[product]++;
            }
        }

        return 4 * productCounts.Values.Select(count => count * (count - 1)).Sum();
    }
}
