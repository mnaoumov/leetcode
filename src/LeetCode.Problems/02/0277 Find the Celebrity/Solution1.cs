namespace LeetCode.Problems._0277_Find_the_Celebrity;

/// <seealso href="https://leetcode.com/submissions/detail/1468008253/"/>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : Relation, ISolution
{
    public int FindCelebrity(int n)
    {
        var celebrityCandidates = Enumerable.Range(0, n).ToHashSet();

        for (var i = 0; i < n; i++)
        {
            if (!celebrityCandidates.Contains(i))
            {
                continue;
            }

            for (var j = 0; j < n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                celebrityCandidates.Remove(Knows(i, j) ? i : j);
            }
        }

        return celebrityCandidates.Count == 1 ? celebrityCandidates.First() : -1;
    }
}
