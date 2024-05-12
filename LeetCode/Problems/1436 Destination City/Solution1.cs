using JetBrains.Annotations;

namespace LeetCode.Problems._1436_Destination_City;

/// <summary>
/// https://leetcode.com/problems/destination-city/submissions/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string DestCity(IList<IList<string>> paths)
    {
        var sources = new HashSet<string>();
        var destinations = new HashSet<string>();

        foreach (var path in paths)
        {
            sources.Add(path[0]);
            destinations.Add(path[1]);
        }

        destinations.ExceptWith(sources);

        return destinations.Single();
    }
}
