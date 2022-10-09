namespace LeetCode._0658_Find_K_Closest_Elements;

/// <summary>
/// https://leetcode.com/submissions/detail/811499542/
/// </summary>
public class Solution1
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        var i = FindClosestIndex();

        var result = new List<int> { arr[i] };

        var indexToLeft = i - 1;
        var indexToRight = i + 1;

        while (result.Count < k)
        {
            var distanceToLeft = GetDistanceToElementWithIndex(indexToLeft);
            var distanceToRight = GetDistanceToElementWithIndex(indexToRight);

            if (distanceToLeft <= distanceToRight)
            {
                result.Add(arr[indexToLeft]);
                indexToLeft--;
            }
            else
            {
                result.Add(arr[indexToRight]);
                indexToRight++;
            }
        }

        result.Sort();

        return result;

        int FindClosestIndex()
        {
            var left = 0;
            var right = arr.Length - 1;

            while (right - left > 1)
            {
                var mid = (left + right) / 2;
                var value = arr[mid];

                if (value < x)
                {
                    left = mid;
                }
                else if (value > x)
                {
                    right = mid;
                }
                else
                {
                    return mid;
                }
            }

            var distanceToLeftEl = GetDistanceToElementWithIndex(left);
            var distanceToNextToLeftEl = GetDistanceToElementWithIndex(left + 1);

            return distanceToLeftEl <= distanceToNextToLeftEl ? left : left + 1;
        }

        int GetDistanceToElementWithIndex(int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                return int.MaxValue;
            }

            return Math.Abs(arr[index] - x);
        }
    }
}