namespace LeetCode.Problems._3321_Find_X_Sum_of_All_K_Long_Subarrays_II;

/// <summary>
/// https://leetcode.com/problems/find-x-sum-of-all-k-long-subarrays-ii/submissions/1821039542/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long[] FindXSum(int[] nums, int k, int x)
    {
        var counts = new Dictionary<int, int>();

        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            counts.TryAdd(num, 0);
            counts[num]++;
        }

        var sortedKeys = new List<Key>();

        foreach (var num in counts.Keys)
        {
            var key = GetKey(num);
            var index = ~sortedKeys.BinarySearch(key);
            sortedKeys.Insert(index, key);
        }

        var n = nums.Length;
        var ans = new long[n - k + 1];

        var sum = sortedKeys.Take(Math.Min(x, sortedKeys.Count)).Select(key => key.TotalCount).Sum();
        ans[0] = sum;

        for (var i = 1; i < n - k + 1; i++)
        {
            var oldNum = nums[i - 1];
            var oldNumKey = GetKey(oldNum);
            RemoveKey(oldNumKey);
            counts[oldNum]--;
            var oldNumUpdatedKey = GetKey(oldNum);
            InsertKey(oldNumUpdatedKey);

            var newNum = nums[i + k - 1];
            counts.TryAdd(newNum, 0);
            var newNumKey = GetKey(newNum);
            RemoveKey(newNumKey);
            counts[newNum]++;
            var newNumUpdatedKey = GetKey(newNum);
            InsertKey(newNumUpdatedKey);
            ans[i] = sum;
        }

        return ans;

        Key GetKey(int num) => new(num, counts[num]);

        void RemoveKey(Key key)
        {
            var index = sortedKeys.BinarySearch(key);

            if (index < 0)
            {
                return;
            }

            sortedKeys.RemoveAt(index);

            if (index >= x)
            {
                return;
            }

            sum -= key.TotalCount;

            if (sortedKeys.Count >= x)
            {
                sum += sortedKeys[x - 1].TotalCount;
            }
        }

        void InsertKey(Key key)
        {
            var index = ~sortedKeys.BinarySearch(key);

            if (index < 0)
            {
                throw new InvalidOperationException($"Duplicated key {key}");
            }

            sortedKeys.Insert(index, key);

            if (index >= x)
            {
                return;
            }

            sum += key.TotalCount;

            if (sortedKeys.Count > x)
            {
                sum -= sortedKeys[x].TotalCount;
            }
        }
    }

    private record Key(int Num, int Count) : IComparable<Key>
    {
        public long TotalCount => 1L * Num * Count;

        public int CompareTo(Key? other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (other is null)
            {
                return 1;
            }

            return (-Count, -Num).CompareTo((-other.Count, -other.Num));
        }
    }
}
