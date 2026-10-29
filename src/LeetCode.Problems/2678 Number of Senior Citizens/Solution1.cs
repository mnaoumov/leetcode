namespace LeetCode.Problems._2678_Number_of_Senior_Citizens;

/// <summary>
/// https://leetcode.com/submissions/detail/1341283468/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSeniors(string[] details)
    {
        const int ageStartIndex = 11;
        const int ageStrLength = 2;

        return details.Count(detail => int.Parse(detail.Substring(ageStartIndex, ageStrLength)) > 60);
    }
}
