using JetBrains.Annotations;

namespace LeetCode._0881_Boats_to_Save_People;

/// <summary>
/// https://leetcode.com/submissions/detail/914072629/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumRescueBoats(int[] people, int limit)
    {
        Array.Sort(people);

        var minIndex = 0;
        var maxIndex = people.Length - 1;

        var result = 0;

        while (minIndex <= maxIndex)
        {
            if (minIndex < maxIndex && people[maxIndex] + people[minIndex] <= limit)
            {
                minIndex++;
            }

            maxIndex--;
            result++;
        }

        return result;
    }
}
