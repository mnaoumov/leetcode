namespace LeetCode.Problems._1213_Intersection_of_Three_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1446366666/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3)
    {
        var ans = new List<int>();
        var arrays = new[] { arr1, arr2, arr3 };
        var n = arrays.Length;
        var indices = new int[n];

        while (true)
        {
            var last = ans.Count == 0 ? int.MinValue : ans[^1];
            var minArrayIndex = -1;
            var minValue = int.MaxValue;
            var maxValue = int.MinValue;
            for (var i = 0; i < n; i++)
            {
                var arr = arrays[i];

                while (indices[i] < arr.Length && arr[indices[i]] < last)
                {
                    indices[i]++;
                }

                if (indices[i] == arr.Length)
                {
                    return ans;
                }

                if (arr[indices[i]] < minValue)
                {
                    minValue = arr[indices[i]];
                    minArrayIndex = i;
                }

                if (arr[indices[i]] > maxValue)
                {
                    maxValue = arr[indices[i]];
                }
            }

            if (minValue == maxValue)
            {
                ans.Add(minValue);

                for (var i = 0; i < n; i++)
                {
                    indices[i]++;
                }
            }
            else
            {
                indices[minArrayIndex]++;
            }
        }
    }
}
