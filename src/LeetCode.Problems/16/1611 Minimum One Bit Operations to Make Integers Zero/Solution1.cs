namespace LeetCode.Problems._1611_Minimum_One_Bit_Operations_to_Make_Integers_Zero;

/// <summary>
/// https://leetcode.com/submissions/detail/1109253791/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinimumOneBitOperations(int n)
    {
        var queue = new Queue<(int num, int step)>();
        queue.Enqueue((n, 0));
        var seen = new HashSet<int>();

        while (true)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (num, step) = queue.Dequeue();

                if (num == 0)
                {
                    return step;
                }

                if (!seen.Add(num))
                {
                    continue;
                }

                queue.Enqueue((num ^ 1, step + 1));

                var rightmostOneBit = 0;

                while ((num & 1 << rightmostOneBit) == 0)
                {
                    rightmostOneBit++;
                }

                queue.Enqueue((num ^ 1 << rightmostOneBit + 1, step + 1));
            }
        }
    }
}
