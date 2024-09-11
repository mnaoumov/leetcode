using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2260_Minimum_Consecutive_Cards_to_Pick_Up;

/// <summary>
/// https://leetcode.com/submissions/detail/856715082/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumCardPickup(int[] cards)
    {
        var cardIndices = new Dictionary<int, int>();

        var result = int.MaxValue;

        for (var i = 0; i < cards.Length; i++)
        {
            var card = cards[i];

            if (cardIndices.TryGetValue(card, out var index))
            {
                result = Math.Min(result, card - index + 1);
            }

            cardIndices[card] = i;
        }

        return result == int.MaxValue ? -1 : result;
    }
}
