using JetBrains.Annotations;

namespace LeetCode._0649_Dota2_Senate;

/// <summary>
/// https://leetcode.com/submissions/detail/903209412/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string PredictPartyVictory(string senate)
    {
        var queue = new Queue<Party>();

        var senatorCounts = new Dictionary<Party, int>
        {
            [Party.Radiant] = 0,
            [Party.Dire] = 0
        };

        Party party;

        foreach (var partyLetter in senate)
        {
            const char radiantLetter = 'R';
            party = partyLetter == radiantLetter ? Party.Radiant : Party.Dire;
            queue.Enqueue(party);
            senatorCounts[party]++;
        }

        var bansAvailable = new Dictionary<Party, int>
        {
            [Party.Radiant] = 0,
            [Party.Dire] = 0
        };
        
        while (true)
        {
            party = queue.Dequeue();

            if (bansAvailable[party] > 0)
            {
                bansAvailable[party]--;
                senatorCounts[party]--;
            }
            else
            {
                var otherParty = party == Party.Radiant ? Party.Dire : Party.Radiant;
                if (senatorCounts[otherParty] == 0)
                {
                    return party.ToString();
                }

                queue.Enqueue(party);
                bansAvailable[otherParty]++;
            }
        }
    }

    private enum Party
    {
        Radiant,
        Dire
    }
}
