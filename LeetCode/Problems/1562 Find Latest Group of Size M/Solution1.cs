using JetBrains.Annotations;

namespace LeetCode._1562_Find_Latest_Group_of_Size_M;

/// <summary>
/// https://leetcode.com/submissions/detail/966403446/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindLatestStep(int[] arr, int m)
    {
        var ans = -1;

        var oneGroups = new List<(int from, int to)>();
        var mGroupCounts = 0;

        for (var i = 1; i <= arr.Length; i++)
        {
            var num = arr[i - 1];
            var low = 0;
            var high = oneGroups.Count - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (oneGroups[mid].from <= num)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            int insertionIndex;

            if (high == -1 || oneGroups[high].to < num - 1)
            {
                InsertGroup(high + 1, num, num);
                insertionIndex = high + 1;
            }
            else
            {
                InsertGroup(high + 1, oneGroups[high].from, num);
                RemoveGroup(high);
                insertionIndex = high;
            }

            if (insertionIndex + 1 != oneGroups.Count && oneGroups[insertionIndex + 1].from == num + 1)
            {
                InsertGroup(insertionIndex, oneGroups[insertionIndex].from, oneGroups[insertionIndex + 1].to);
                RemoveGroup(insertionIndex + 2);
                RemoveGroup(insertionIndex + 1);
            }

            if (mGroupCounts > 0)
            {
                ans = i;
            }
        }

        return ans;

        void InsertGroup(int index, int from, int to)
        {
            oneGroups.Insert(index, (from, to));
            var length = to - from + 1;

            if (length == m)
            {
                mGroupCounts++;
            }
        }

        void RemoveGroup(int index)
        {
            var (from, to) = oneGroups[index];
            var length = to - from + 1;
            oneGroups.RemoveAt(index);
            if (length == m)
            {
                mGroupCounts--;
            }
        }
    }
}
