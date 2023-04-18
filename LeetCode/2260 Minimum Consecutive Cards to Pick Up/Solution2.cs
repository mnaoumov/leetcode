using JetBrains.Annotations;

namespace LeetCode._2260_Minimum_Consecutive_Cards_to_Pick_Up;

/// <summary>
/// https://leetcode.com/submissions/detail/856716093/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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
                result = Math.Min(result, i - index + 1);
            }

            cardIndices[card] = i;
        }

        return result == int.MaxValue ? -1 : result;
    }
}
