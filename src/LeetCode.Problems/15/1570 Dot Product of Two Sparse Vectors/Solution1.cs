namespace LeetCode.Problems._1570_Dot_Product_of_Two_Sparse_Vectors;

/// <summary>
/// https://leetcode.com/problems/dot-product-of-two-sparse-vectors/submissions/1808231806/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISparseVector Create(int[] nums) => new SparseVector(nums);

    private class SparseVector : ISparseVector
    {
        private readonly Dictionary<int, int> _dict = new();
        public SparseVector(int[] nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    continue;
                }

                _dict[i] = nums[i];
            }
        }

        public int DotProduct(ISparseVector vec) => DotProduct((SparseVector) vec);

        private int DotProduct(SparseVector vec)
        {
            var ans = 0;

            foreach (var (vecIndex, vecNum) in vec._dict)
            {
                if (_dict.TryGetValue(vecIndex, out var num))
                {
                    ans += num * vecNum;
                }
            }

            return ans;
        }
    }
}
