

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2456_Most_Popular_Video_Creator;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-317/submissions/detail/833060894/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views)
    {
        var groupByCreator =
            creators
                .Zip(ids, (creator, id) => (creator, id))
                .Zip(views, (x, view) => (x.creator, x.id, view))
                .GroupBy(x => x.creator)
                .Select(group => (creator: group.Key, popularity: group.Select(x => x.view).Sum(), group: group))
                .ToArray();

        var maxPopularity = groupByCreator.Select(x => x.popularity).Max();

        return groupByCreator.Where(x => x.popularity == maxPopularity).Select(x => new[]
        {
            x.creator,
            x.group.OrderByDescending(y => y.view).ThenBy(y => y.id).First().id
        }).ToArray<IList<string>>();
    }
}
