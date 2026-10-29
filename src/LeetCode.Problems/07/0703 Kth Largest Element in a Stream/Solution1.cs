namespace LeetCode.Problems._0703_Kth_Largest_Element_in_a_Stream;

/// <summary>
/// https://leetcode.com/submissions/detail/908028755/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IKthLargest Create(int k, int[] nums) => new KthLargest1(k, nums);

    private class KthLargest1 : IKthLargest
    {
        private readonly int _k;
        private readonly PriorityQueue<int, int> _heap = new();

        public KthLargest1(int k, IEnumerable<int> nums)
        {
            _k = k;

            foreach (var num in nums)
            {
                Add(num);
            }
        }

        public int Add(int val)
        {
            _heap.Enqueue(val, val);

            if (_heap.Count == _k + 1)
            {
                _heap.Dequeue();
            }

            return _heap.Peek();
        }
    }
}
