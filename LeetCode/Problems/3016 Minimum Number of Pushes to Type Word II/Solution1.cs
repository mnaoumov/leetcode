using JetBrains.Annotations;

namespace LeetCode.Problems._3016_Minimum_Number_of_Pushes_to_Type_Word_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-381/submissions/detail/1152141294/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumPushes(string word)
    {
        var repeatedLetterCount = word.GroupBy(letter => letter).Select(g => g.Count()).OrderByDescending(x => x).ToArray();

        const int buttonsCount = 8;

        var ans = 0;
        var pushesCount = 1;
        var index = 0;

        while (index < repeatedLetterCount.Length)
        {
            var assignments = Math.Min(repeatedLetterCount.Length - index, buttonsCount);

            for (var i = index; i < index + assignments; i++)
            {
                ans += pushesCount * repeatedLetterCount[i];
            }

            pushesCount++;
            index += assignments;
        }

        return ans;
    }
}
