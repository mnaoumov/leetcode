namespace LeetCode.Problems._3714_Longest_Balanced_Substring_II;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int LongestBalanced(string s)
    {
        const int any = int.MinValue;

        var diffIndexMap = new Dictionary<Count, int>
        {
            [new Count(0, 0, 0)] = -1,
            [new Count(any, 0, 0)] = -1,
            [new Count(0, any, 0)] = -1,
            [new Count(0, 0, any)] = -1,
            [new Count(any, any, 0)] = -1,
            [new Count(0, any, any)] = -1,
            [new Count(any, 0, any)] = -1
        };

        var countA = 0;
        var countB = 0;
        var countC = 0;

        var ans = 0;

        for (var index = 0; index < s.Length; index++)
        {
            var letter = s[index];

            switch (letter)
            {
                case 'a':
                    countA++;
                    break;
                case 'b':
                    countB++;
                    break;
                case 'c':
                    countC++;
                    break;
            }

            var min = new[] { countA, countB, countC }.Min();

            var diffs = new List<Count> { new Count(countA - min, countB - min, countC - min) };

            if (min == 0)
            {
                var nonZeroMin = new[] { countA, countB, countC }.Where(c => c > 0).Min();
                diffs.Add(new Count(
                    countA == 0 ? any : countA - nonZeroMin,
                    countB == 0 ? any : countB - nonZeroMin,
                    countC == 0 ? any : countC - nonZeroMin
                ));
            }

            foreach (var diff in diffs)
            {
                if (diffIndexMap.TryGetValue(diff, out var previousIndex))
                {
                    ans = Math.Max(ans, index - previousIndex);
                }
                else
                {
                    diffIndexMap.Add(diff, index);
                }
            }
        }

        return ans;
    }

    private record Count(int A, int B, int C);
}
