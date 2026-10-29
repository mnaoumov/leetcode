namespace LeetCode.Problems._2508_Add_Edges_to_Make_Degrees_of_All_Nodes_Even;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-324/submissions/detail/861426804/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IsPossible(int n, IList<IList<int>> edges)
    {
        var neighbors = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var oddNodes = Enumerable.Range(1, n).Where(node => neighbors[node].Count % 2 == 1).ToHashSet();
        var evenNodes = Enumerable.Range(1, n).Where(node => neighbors[node].Count % 2 == 0)
            .OrderBy(node => neighbors[node].Count).ToHashSet();

        var evenCandidatesMap = new Dictionary<int, HashSet<int>>();

        if (oddNodes.Count > 4)
        {
            return false;
        }

        while (oddNodes.Count > 0)
        {
            var oddNode1 = oddNodes.First();

            if (neighbors[oddNode1].Count == n - 1)
            {
                return false;
            }

            var oddCandidates = new HashSet<int>(oddNodes);
            oddCandidates.Remove(oddNode1);
            oddCandidates.ExceptWith(neighbors[oddNode1]);

            int oddNode2;

            if (oddCandidates.Count > 0)
            {
                oddNode2 = oddCandidates.First();
            }
            else
            {
                var evenCandidates = GetEvenCandidates(oddNode1);
                oddNode2 = oddNodes.FirstOrDefault(oddNode => oddNode != oddNode1 && GetEvenCandidates(oddNode).Overlaps(evenCandidates));

                if (oddNode2 == 0)
                {
                    return false;
                }
            }

            oddNodes.Remove(oddNode1);
            oddNodes.Remove(oddNode2);
        }

        return true;

        HashSet<int> GetEvenCandidates(int node)
        {
            if (evenCandidatesMap.TryGetValue(node, out var result))
            {
                return result;
            }

            evenCandidatesMap[node] = result = new HashSet<int>(evenNodes);
            result.ExceptWith(neighbors[node]);
            return result;
        }
    }
}
