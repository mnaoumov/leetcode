namespace LeetCode.Problems._1962_Remove_Stones_to_Minimize_the_Total;

/// <summary>
/// https://leetcode.com/submissions/detail/867119351/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinStoneSum(int[] piles, int k)
    {
        var pq = new PriorityQueue<int, int>();
        var result = piles.Sum();
        foreach (var pile in piles)
        {
            pq.Enqueue(pile, -pile);
        }

        for (var i = 0; i < k; i++)
        {
            var pile = pq.Dequeue();
            if (pile <= 1)
            {
                break;
            }

            result -= pile / 2;
            pile -= pile / 2;
            pq.Enqueue(pile, -pile);
        }

        return result;
    }
}
