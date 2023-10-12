using JetBrains.Annotations;

namespace LeetCode._1095_Find_in_Mountain_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1073080148/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        var low = 1;
        var length = mountainArr.Length();
        var high = length - 2;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (mountainArr.Get(mid) > mountainArr.Get(mid + 1))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        var peekIndex = high;

        low = 0;
        high = peekIndex;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var value = mountainArr.Get(mid);

            if (value == target)
            {
                return mid;
            }

            if (value > target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        low = peekIndex + 1;
        high = length - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);
            var value = mountainArr.Get(mid);

            if (value == target)
            {
                return mid;
            }

            if (value < target)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }
}
