namespace LeetCode.Problems._2491_Divide_Players_Into_Teams_of_Equal_Skill;

/// <summary>
/// https://leetcode.com/submissions/detail/856184774/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long DividePlayers(int[] skill) => DividePlayersImpl(skill);

    private static long DividePlayersImpl(IReadOnlyCollection<int> skills)
    {
        var totalSum = skills.Sum();

        const int impossible = -1;

        var groupsCount = skills.Count / 2;

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

            if (!countMap.TryGetValue(otherSkill, out var value) || value != count)
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
