using JetBrains.Annotations;

namespace LeetCode._1287_Element_Appearing_More_Than_25__In_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1116946754/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindSpecialInteger(int[] arr)
    {
        var lastNum = int.MinValue;
        var count = 0;
        var minCount = 1 + (int) Math.Floor(arr.Length * 0.25);


        foreach (var num in arr)
        {
            if (num != lastNum)
            {
                count = 1;
            }
            else
            {
                count++;
            }

            if (count >= minCount)
            {
                return num;
            }

            lastNum = num;
        }

        throw new InvalidOperationException();
    }
}
