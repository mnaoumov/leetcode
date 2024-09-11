namespace LeetCode.Problems._2445_Number_of_Nodes_With_Value_One;

/// <summary>
/// https://leetcode.com/submissions/detail/882110921/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfNodes(int n, int[] queries)
    {
        var queriesSet = new HashSet<int>();

        foreach (var query in queries)
        {
            if (!queriesSet.Add(query))
            {
                queriesSet.Remove(query);
            }
        }

        var oneNodes = new HashSet<int>();

        for (var i = 1; i <= n; i++)
        {
            var isOneNode = oneNodes.Contains(i / 2) ^ queriesSet.Contains(i);

            if (isOneNode)
            {
                oneNodes.Add(i);
            }
        }

        return oneNodes.Count;
    }
}
