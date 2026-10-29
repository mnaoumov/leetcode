namespace LeetCode.Problems._2425_Bitwise_XOR_of_All_Pairings;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int XorAllNums(int[] nums1, int[] nums2)
    {
        var ans = 0;

        if (nums1.Length % 2 == 1)
        {
            ans ^= Xor(nums2);
        }

        if (nums2.Length % 2 == 1)
        {
            ans ^= Xor(nums1);
        }
        
        return ans;
    }

    private static int Xor(int[] nums) => nums.Aggregate(0, (current, num) => current ^ num);
}
