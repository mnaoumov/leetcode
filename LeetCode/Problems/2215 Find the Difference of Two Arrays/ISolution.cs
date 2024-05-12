using JetBrains.Annotations;

namespace LeetCode._2215_Find_the_Difference_of_Two_Arrays;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2);
}
