using JetBrains.Annotations;

namespace LeetCode.Problems._1710_Maximum_Units_on_a_Truck;

/// <summary>
/// https://leetcode.com/submissions/detail/914077612/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumUnits(int[][] boxTypes, int truckSize)
    {
        var result = 0;

        foreach (var (numberOfBoxes, numberOfUnitsPerBox) in boxTypes.Select(x => (numberOfBoxes: x[0], numberOfUnitsPerBox: x[1])).OrderByDescending(x => x.numberOfUnitsPerBox))
        {
            var numberOfBoxesTaken = Math.Min(numberOfBoxes, truckSize);
            result += numberOfBoxesTaken * numberOfUnitsPerBox;
            truckSize -= numberOfBoxesTaken;

            if (truckSize == 0)
            {
                break;
            }
        }

        return result;
    }
}
