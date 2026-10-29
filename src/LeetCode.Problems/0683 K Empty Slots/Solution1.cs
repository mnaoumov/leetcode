namespace LeetCode.Problems._0683_K_Empty_Slots;

/// <summary>
/// https://leetcode.com/problems/k-empty-slots/submissions/1672089514/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KEmptySlots(int[] bulbs, int k)
    {
        var turnedOnBulbs = new List<int>();

        for (var i = 0; i < bulbs.Length; i++)
        {
            var bulb = bulbs[i];
            var index = ~turnedOnBulbs.BinarySearch(bulb);
            turnedOnBulbs.Insert(index, bulb);

            if (index > 0 && turnedOnBulbs[index - 1] == bulb - k - 1 || index < turnedOnBulbs.Count - 1 && turnedOnBulbs[index + 1] == bulb + k + 1)
            {
                return i + 1;
            }
        }

        return -1;
    }
}
