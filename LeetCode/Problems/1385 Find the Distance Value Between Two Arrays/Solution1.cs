using JetBrains.Annotations;

namespace LeetCode.Problems._1385_Find_the_Distance_Value_Between_Two_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/924594155/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        Array.Sort(arr2);

        var result = 0;

        foreach (var num1 in arr1)
        {
            var index1 = Array.BinarySearch(arr2, num1 - d);
            var index2 = Array.BinarySearch(arr2, num1 + d);

            if (index1 < 0)
            {
                index1 = ~index1;
            }

            if (index2 < 0)
            {
                index2 = ~index2 - 1;
            }

            if (index1 == arr2.Length || index1 > index2)
            {
                result++;
            }
        }

        return result;
    }
}
