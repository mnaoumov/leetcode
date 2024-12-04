namespace LeetCode.Problems._0277_Find_the_Celebrity;

/// <summary>
/// https://leetcode.com/submissions/detail/1468014473/
/// </summary>
[UsedImplicitly]
public class Solution2 : Relation, ISolution
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

        foreach (var celebrityCandidate in celebrityCandidates)
        {
            var isCelebrity = true;

            for (var i = 0; i < n; i++)
            {
                if (i == celebrityCandidate)
                {
                    continue;
                }

                if (Knows(i, celebrityCandidate))
                {
                    continue;
                }

                isCelebrity = false;
                break;
            }

            if (isCelebrity)
            {
                return celebrityCandidate;
            }
        }

        return -1;
    }
}
