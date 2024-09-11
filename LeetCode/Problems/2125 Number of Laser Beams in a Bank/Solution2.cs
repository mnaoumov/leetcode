namespace LeetCode.Problems._2125_Number_of_Laser_Beams_in_a_Bank;

/// <summary>
/// https://leetcode.com/submissions/detail/1135136739/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfBeams(string[] bank)
    {
        const char securityDevice = '1';
        var counts = bank.Select(row => row.Count(cell => cell == securityDevice)).Where(count => count > 0).ToArray();
        return counts.Length == 0 ? 0 : Enumerable.Range(0, counts.Length - 1).Sum(i => counts[i] * counts[i + 1]);
    }
}
