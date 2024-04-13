using JetBrains.Annotations;

namespace LeetCode._0950_Reveal_Cards_In_Increasing_Order;

/// <summary>
/// https://leetcode.com/submissions/detail/1228948187/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DeckRevealedIncreasing(int[] deck)
    {
        var list = new List<int>();

        foreach (var card in deck.OrderByDescending(x=>x))
        {
            if (list.Count > 1)
            {
                list.Insert(0, list[^1]);
                list.RemoveAt(list.Count - 1);
            }

            list.Insert(0, card);
        }

        return list.ToArray();
    }
}
