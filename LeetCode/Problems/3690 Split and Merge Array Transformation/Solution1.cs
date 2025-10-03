namespace LeetCode.Problems._3690_Split_and_Merge_Array_Transformation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-468/problems/split-and-merge-array-transformation/submissions/1777644423/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinSplitMerge(int[] nums1, int[] nums2)
    {
        var seen = new HashSet<string>();
        var queue = new Queue<int[]>();
        queue.Enqueue(nums1);
        var ans = 0;
        var nums2Str = ToString(nums2);
        var n = nums1.Length;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var arr = queue.Dequeue();
                var str = ToString(arr);

                if (str == nums2Str)
                {
                    return ans;
                }

                seen.Add(str);

                for (var l = 0; l < n - 1; l++)
                {
                    for (var r = l + 1; r < n; r++)
                    {
                        var length = r - l + 1;
                        var list = arr.ToList();
                        list.RemoveRange(l, length);

                        for (var j = 0; j < list.Count; j++)
                        {
                            list.InsertRange(j, arr[l..(r + 1)]);
                            queue.Enqueue(list.ToArray());
                            list.RemoveRange(j, length);
                        }
                    }
                }
            }

            ans++;
        }

        return ans;
    }

    private static string ToString(int[] arr) => string.Join(",", arr);
}
