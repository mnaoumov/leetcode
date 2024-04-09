using JetBrains.Annotations;

namespace LeetCode._0255_Verify_Preorder_Sequence_in_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1227192319/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool VerifyPreorder(int[] preorder)
    {
        var dp = new Dictionary<(int startIndex, int endIndex), bool>();
        return Verify(0, preorder.Length - 1);

        bool Verify(int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return true;
            }

            var key = (startIndex, endIndex);

            if (dp.TryGetValue(key, out var ans))
            {
                return ans;
            }

            var head = preorder[startIndex];

            var leftSubtreeEndIndex = startIndex;

            while (leftSubtreeEndIndex + 1 <= endIndex && preorder[leftSubtreeEndIndex + 1] < head)
            {
                leftSubtreeEndIndex++;
            }

            var rightSubtreeEndIndex = leftSubtreeEndIndex;

            while (rightSubtreeEndIndex + 1 <= endIndex && preorder[rightSubtreeEndIndex + 1] > head)
            {
                rightSubtreeEndIndex++;
            }

            dp[key] = rightSubtreeEndIndex == endIndex
                      && Verify(startIndex + 1, leftSubtreeEndIndex)
                      && Verify(leftSubtreeEndIndex + 1, endIndex);

            return dp[key];
        }
    }
}
