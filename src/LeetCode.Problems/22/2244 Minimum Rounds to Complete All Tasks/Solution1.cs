namespace LeetCode.Problems._2244_Minimum_Rounds_to_Complete_All_Tasks;

/// <seealso href="https://leetcode.com/submissions/detail/870802634/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumRounds(int[] tasks)
    {
        var counts = tasks.GroupBy(difficulty => difficulty).Select(g => g.Count()).ToArray();

        var result = 0;

        foreach (var count in counts)
        {
            if (count == 1)
            {
                return -1;
            }

            result += (int) Math.Ceiling(count / 3d);
        }

        return result;
    }
}
