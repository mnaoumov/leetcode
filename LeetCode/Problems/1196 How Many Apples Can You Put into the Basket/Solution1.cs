using JetBrains.Annotations;

namespace LeetCode.Problems._1196_How_Many_Apples_Can_You_Put_into_the_Basket;

/// <summary>
/// https://leetcode.com/submissions/detail/914078563/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxNumberOfApples(int[] weight)
    {
        var result = 0;
        var capacity = 5000;

        foreach (var apple in weight.OrderBy(x => x))
        {
            if (apple > capacity)
            {
                break;
            }

            capacity -= apple;
            result++;
        }

        return result;
    }
}
