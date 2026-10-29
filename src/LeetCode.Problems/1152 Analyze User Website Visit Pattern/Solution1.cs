namespace LeetCode.Problems._1152_Analyze_User_Website_Visit_Pattern;

/// <summary>
/// https://leetcode.com/problems/analyze-user-website-visit-pattern/submissions/1778586901/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> MostVisitedPattern(string[] username, int[] timestamp, string[] website)
    {
        var n = username.Length;
        var entries = Enumerable.Range(0, n).Select(i => new Entry(username[i], timestamp[i], website[i]))
            .OrderBy(v => v.Timestamp)
            .ToArray();

        var entriesByUsers = entries.GroupBy(e => e.UserName).ToDictionary(g => g.Key, g => g.ToArray());

        var counts = new Dictionary<string, int>();

        foreach (var (_, userEntries) in entriesByUsers)
        {
            var m = userEntries.Length;

            for (var i = 0; i < m; i++)
            {
                for (var j = i + 1; j < m; j++)
                {
                    for (var k = j + 1; k < m; k++)
                    {
                        var pattern = new[] { userEntries[i].Website, userEntries[j].Website, userEntries[k].Website };
                        var patternStr = string.Join(' ', pattern);
                        counts.TryAdd(patternStr, 0);
                        counts[patternStr]++;
                    }
                }
            }
        }

        var maxCount = counts.Values.Max();
        var ansPatternStr = counts.Where(kvp => kvp.Value == maxCount).Select(kvp => kvp.Key).OrderBy(x => x).First();
        return ansPatternStr.Split(' ');
    }

    private record Entry(string UserName, int Timestamp, string Website);
}
