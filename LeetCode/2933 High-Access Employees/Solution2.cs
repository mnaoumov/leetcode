using JetBrains.Annotations;

namespace LeetCode._2933_High_Access_Employees;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-371/submissions/detail/1096960218/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
    {
        return access_times
            .GroupBy(x => x[0], x => TimeSpan.ParseExact(x[1], "hhmm", null))
            .Where(g =>
            {
                var orderedTimes = g.OrderBy(t => t).ToArray();

                if (orderedTimes.Length < 3)
                {
                    return false;
                }

                for (var i = 2; i < orderedTimes.Length; i++)
                {
                    if (orderedTimes[i].Subtract(orderedTimes[i - 2]).TotalHours < 1)
                    {
                        return true;
                    }
                }

                return false;
            })
            .Select(g => g.Key)
            .ToArray();
    }
}
