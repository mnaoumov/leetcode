namespace LeetCode.Problems._0496_Next_Greater_Element_I;

/// <summary>
/// https://leetcode.com/submissions/detail/882846079/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var valueIndexMap1 = nums1.Select((num, index) => (num, index)).ToDictionary(x => x.num, x => x.index);
        var monotonic2 = new Stack<int>();
        var result = Enumerable.Repeat(-1, nums1.Length).ToArray();

        foreach (var num in nums2)
        {
            while (monotonic2.Count > 0 && monotonic2.Peek() < num)
            {
                var smallerNum = monotonic2.Pop();

                if (valueIndexMap1.TryGetValue(smallerNum, out var index1))
                {
                    result[index1] = num;
                }
            }

            monotonic2.Push(num);
        }

        return result;
    }
}
