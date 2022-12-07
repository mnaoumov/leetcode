using JetBrains.Annotations;

namespace LeetCode._2491_Divide_Players_Into_Teams_of_Equal_Skill;

/// <summary>
/// https://leetcode.com/problems/divide-players-into-teams-of-equal-skill/submissions/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long DividePlayers(int[] skill) => DividePlayersImpl(skill);

    private static long DividePlayersImpl(int[] skills)
    {
        var totalSum= skills.Sum();

        const int impossible = -1;

        var groupsCount = skills.Length / 2;

        if (totalSum % groupsCount != 0)
        {
            return impossible;
        }

        var sum = totalSum / groupsCount;

        var countMap = skills.GroupBy(s => s).ToDictionary(g => g.Key, g => g.Count());

        long result = 0;

        foreach (var skill in countMap.Keys)
        {
            var count = countMap[skill];
            var otherSkill = sum - skill;

            if (!countMap.ContainsKey(otherSkill))
            {
                return impossible;
            }

            if (countMap[otherSkill] != count)
            {
                return impossible;
            }

            if (skill == otherSkill)
            {
                if (count % 2 == 0)
                {
                    count /= 2;
                }
                else
                {
                    return impossible;
                }
            }

            result += (long) skill * otherSkill * count;

            countMap.Remove(skill);
            countMap.Remove(otherSkill);
        }

        return result;
    }
}
