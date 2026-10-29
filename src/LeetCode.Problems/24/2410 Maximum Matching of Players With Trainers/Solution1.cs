namespace LeetCode.Problems._2410_Maximum_Matching_of_Players_With_Trainers;

/// <summary>
/// https://leetcode.com/submissions/detail/914088944/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers)
    {
        Array.Sort(players);
        Array.Sort(trainers);

        var trainerIndex = 0;
        var result = 0;

        foreach (var playerAbility in players)
        {
            while (trainerIndex < trainers.Length && trainers[trainerIndex] < playerAbility)
            {
                trainerIndex++;
            }

            if (trainerIndex == trainers.Length)
            {
                break;
            }

            result++;
            trainerIndex++;
        }

        return result;
    }
}
