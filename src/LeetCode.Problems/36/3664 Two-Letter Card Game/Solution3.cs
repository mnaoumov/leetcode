namespace LeetCode.Problems._3664_Two_Letter_Card_Game;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-164/problems/two-letter-card-game/submissions/1753743381/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int Score(string[] cards, char x)
    {
        var counts = cards
            .Where(card => card[0] == x || card[1] == x)
            .GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        var pq = new PriorityQueue<string, (int inverseCount, int group)>();

        foreach (var card in counts.Keys)
        {
            AddCard(card);
        }

        var ans = 0;

        while (pq.Count > 1)
        {
            var card1 = pq.Dequeue();
            var card2 = pq.Dequeue();

            if (!AreCompatible(card1, card2))
            {
                if (pq.Count == 0)
                {
                    break;
                }

                var card3 = pq.Dequeue();

                if (AreCompatible(card1, card3))
                {
                    AddCard(card2);
                    card2 = card3;
                }
                else
                {
                    AddCard(card1);
                    card1 = card3;
                }
            }

            ans += 1;
            counts[card1]--;
            counts[card2]--;
            if (counts[card1] > 0)
            {
                AddCard(card1);
            }
            if (counts[card2] > 0)
            {
                AddCard(card2);
            }
        }

        return ans;

        void AddCard(string card)
        {
            int group;

            if (card[0] == x && card[1] == x)
            {
                group = 2;
            }
            else if (card[0] == x)
            {
                group = 0;
            }
            else
            {
                group = 1;
            }

            pq.Enqueue(card, (-counts[card], group));
        }
    }

    private static bool AreCompatible(string card1, string card2) =>
        card1 != card2 && (card1[0] == card2[0] || card1[1] == card2[1]);
}
