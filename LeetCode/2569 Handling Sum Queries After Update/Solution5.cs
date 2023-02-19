using JetBrains.Annotations;

namespace LeetCode._2569_Handling_Sum_Queries_After_Update;

/// <summary>
/// https://leetcode.com/submissions/detail/900645255/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries)
    {
        var root = SegmentTreeNode.Build(nums1);
        var result = new List<long>();
        var sum2 = nums2.Select(num => (long) num).Sum();

        foreach (var query in queries)
        {
            var queryType = query[0];

            switch (queryType)
            {
                case 1:
                    var l = query[1];
                    var r = query[2];
                    root.Invert(l, r); 
                    break;
                case 2:
                    var p = query[1];
                    sum2 += 1L * p * root.OnesCount;
                    break;
                case 3:
                    result.Add(sum2);
                    break;
            }
        }

        return result.ToArray();
    }

    private record SegmentTreeNode(int Start, int End)
    {
        private int _onesCount;
        private SegmentTreeNode? LeftNode { get; set; }
        private SegmentTreeNode? RightNode { get; set; }

        public int OnesCount
        {
            get
            {
                if (!ShouldInvert)
                {
                    return _onesCount;
                }

                OnesCount = End - Start + 1 - _onesCount;
                ShouldInvert = false;

                if (Start == End)
                {
                    return _onesCount;
                }

                LeftNode!.ShouldInvert = !LeftNode.ShouldInvert;
                RightNode!.ShouldInvert = !RightNode.ShouldInvert;

                return _onesCount;
            }
            private set => _onesCount = value;
        }

        private bool ShouldInvert { get; set; }

        public void Invert(int leftIndex, int rightIndex)
        {
            if (leftIndex > End || rightIndex < Start)
            {
                return;
            }

            if (leftIndex <= Start && End <= rightIndex)
            {
                ShouldInvert = !ShouldInvert;
            }
            else
            {
                LeftNode!.Invert(leftIndex, rightIndex);
                RightNode!.Invert(leftIndex, rightIndex);
                OnesCount = LeftNode.OnesCount + RightNode.OnesCount;
            }
        }

        public static SegmentTreeNode Build(IReadOnlyList<int> arr) => Build(arr, 0, arr.Count - 1);

        private static SegmentTreeNode Build(IReadOnlyList<int> arr, int start, int end)
        {
            var result = new SegmentTreeNode(start, end);

            if (start == end)
            {
                result.OnesCount = arr[start];
            }
            else
            {
                var mid = (start + end) / 2;
                result.LeftNode = Build(arr, start, mid);
                result.RightNode = Build(arr, mid + 1, end);
                result.OnesCount = result.LeftNode.OnesCount + result.RightNode.OnesCount;
            }

            return result;
        }
    }
}