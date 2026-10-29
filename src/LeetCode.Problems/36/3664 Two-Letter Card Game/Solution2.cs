namespace LeetCode.Problems._3664_Two_Letter_Card_Game;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-164/problems/two-letter-card-game/submissions/1753669345/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int Score(string[] cards, char x)
    {
        var counts = cards
            .Where(card => card[0] == x || card[1] == x)
            .GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        var doubleXCount = 0;
        var firstXCountsPq = new PriorityQueue<int, int>();
        var secondXCountsPq = new PriorityQueue<int, int>();

        foreach (var (card, count) in counts)
        {
            if (card[0] == x && card[1] == x)
            {
                doubleXCount = count;
            }
            else if (card[0] == x)
            {
                firstXCountsPq.Enqueue(count, -count);
            }
            else if (card[1] == x)
            {
                secondXCountsPq.Enqueue(count, -count);
            }
        }

        var ans = 0;

        ProcessQueue(firstXCountsPq);
        ProcessQueue(secondXCountsPq);

        return ans;

        void ProcessQueue(PriorityQueue<int, int> pq)
        {
            while (pq.Count >= 2)
            {
                var count1 = pq.Dequeue();
                var count2 = pq.Dequeue();
                ans++;
                count1--;
                count2--;
                if (count1 > 0)
                {
                    pq.Enqueue(count1, -count1);
                }
                if (count2 > 0)
                {
                    pq.Enqueue(count2, -count2);
                }
            }

            if (pq.Count == 0)
            {
                return;
            }

            var count = pq.Dequeue();
            var min = Math.Min(count, doubleXCount);
            ans += min;
            doubleXCount -= min;
        }
    }
}
