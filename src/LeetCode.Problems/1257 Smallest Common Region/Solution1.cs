namespace LeetCode.Problems._1257_Smallest_Common_Region;

/// <summary>
/// https://leetcode.com/submissions/detail/1390440316/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FindSmallestRegion(IList<IList<string>> regions, string region1, string region2)
    {
        var regionToParentMap = new Dictionary<string, string>();

        foreach (var regionList in regions)
        {
            var parent = regionList[0];

            foreach (var region in regionList.Skip(1))
            {
                regionToParentMap[region] = parent;
            }
        }

        var region1SequenceSet = GetSequence(region1).ToHashSet();

        foreach (var region in GetSequence(region2))
        {
            if (region1SequenceSet.Contains(region))
            {
                return region;
            }
        }

        throw new InvalidOperationException();

        IEnumerable<string> GetSequence(string region)
        {
            yield return region;
            while (regionToParentMap.TryGetValue(region, out var parent))
            {
                region = parent;
                yield return region;
            }
        }
    }
}
