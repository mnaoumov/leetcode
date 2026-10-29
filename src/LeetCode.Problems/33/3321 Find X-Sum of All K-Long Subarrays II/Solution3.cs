namespace LeetCode.Problems._3321_Find_X_Sum_of_All_K_Long_Subarrays_II;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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

        var topXKeys = new SortedSet<Key>();
        var smallerKeys = new SortedSet<Key>();

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var num in counts.Keys)
        {
            var key = GetKey(num);
            topXKeys.Add(key);

            if (topXKeys.Count <= x)
            {
                continue;
            }

            if (topXKeys.Max == null)
            {
                continue;
            }

            smallerKeys.Add(topXKeys.Max);
            topXKeys.Remove(topXKeys.Max);
        }

        var n = nums.Length;
        var ans = new long[n - k + 1];

        var sum = topXKeys.Select(key => key.TotalCount).Sum();
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
            if (topXKeys.Remove(key))
            {
                sum -= key.TotalCount;

                if (topXKeys.Count != x - 1 || smallerKeys.Min == null)
                {
                    return;
                }

                topXKeys.Add(smallerKeys.Min);
                sum += smallerKeys.Min.TotalCount;
                smallerKeys.Remove(smallerKeys.Min);
            }
            else
            {
                smallerKeys.Remove(key);
            }
        }

        void InsertKey(Key key)
        {
            if (topXKeys.Count < x || key.CompareTo(topXKeys.Max) < 0)
            {
                topXKeys.Add(key);

                sum += key.TotalCount;

                // ReSharper disable once InvertIf
                if (topXKeys.Count == x + 1 && topXKeys.Max != null)
                {
                    smallerKeys.Add(topXKeys.Max);
                    sum -= topXKeys.Max.TotalCount;
                    topXKeys.Remove(topXKeys.Max);
                }
            }
            else
            {
                smallerKeys.Add(key);
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
