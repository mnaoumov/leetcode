namespace LeetCode.Problems._0295_Find_Median_from_Data_Stream;

/// <summary>
/// https://leetcode.com/problems/find-median-from-data-stream/submissions/841676521/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMedianFinder Create() => new MedianFinder();

    private class MedianFinder : IMedianFinder
    {
        private readonly List<int> _nums = new();

        public void AddNum(int num)
        {
            var index = _nums.BinarySearch(num);

            if (index < 0)
            {
                index = ~index;
            }

            _nums.Insert(index, num);
        }

        public double FindMedian()
        {
            var mid = (_nums.Count - 1) / 2;
            return _nums.Count % 2 == 1 ? _nums[mid] : (_nums[mid] + _nums[mid + 1]) / 2.0;
        }
    }
}
