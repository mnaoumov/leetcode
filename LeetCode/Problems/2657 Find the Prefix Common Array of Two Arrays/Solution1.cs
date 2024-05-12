using JetBrains.Annotations;

namespace LeetCode.Problems._2657_Find_the_Prefix_Common_Array_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-103/submissions/detail/941584297/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable InconsistentNaming
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    // ReSharper restore InconsistentNaming
    {
        var n = A.Length;
        var aSet = new HashSet<int>();
        var bSet = new HashSet<int>();
        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            aSet.Add(A[i]);
            bSet.Add(B[i]);
            ans[i] = aSet.Intersect(bSet).Count();
        }

        return ans;
    }
}
