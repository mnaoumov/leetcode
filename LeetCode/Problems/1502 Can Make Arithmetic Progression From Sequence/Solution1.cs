using JetBrains.Annotations;

namespace LeetCode._1502_Can_Make_Arithmetic_Progression_From_Sequence;

/// <summary>
/// https://leetcode.com/submissions/detail/925204567/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);

        var diff = arr[1] - arr[0];

        for (var i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i + 1] - arr[i] != diff)
            {
                return false;
            }
        }

        return true;
    }
}
