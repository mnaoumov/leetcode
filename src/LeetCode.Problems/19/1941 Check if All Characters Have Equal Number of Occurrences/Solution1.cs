namespace LeetCode.Problems._1941_Check_if_All_Characters_Have_Equal_Number_of_Occurrences;

/// <seealso href="https://leetcode.com/submissions/detail/856350355/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool AreOccurrencesEqual(string s)
    {
        var count = 0;
        return s.GroupBy(letter => letter).All(g =>
        {
            var groupCount = g.Count();

            if (count == 0)
            {
                count = groupCount;
            }

            return groupCount == count;
        });
    }
}
