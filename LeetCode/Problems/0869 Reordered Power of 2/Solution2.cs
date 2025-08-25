namespace LeetCode.Problems._0869_Reordered_Power_of_2;

/// <summary>
/// https://leetcode.com/problems/reordered-power-of-2/submissions/1730636451/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool ReorderedPowerOf2(int n)
    {
        var digits = GetDigits(n);
        return GetPermutations(digits).Select(MakeNumber).Any(IsPowerOfTwo);
    }

    private static int MakeNumber(int[] digits) => digits.Aggregate(0, (current, digit) => current * 10 + digit);

    private static IList<int[]> GetPermutations(int[] digits)
    {
        var ans = new List<int[]>();

        var list = new List<int>();
        var indicesSet = new HashSet<int>();
        Backtrack();

        return ans;

        void Backtrack()
        {
            if (list.Count == digits.Length)
            {
                ans.Add(list.ToArray());
                return;
            }

            for (var i = 0; i < digits.Length; i++)
            {
                if (!indicesSet.Add(i))
                {
                    continue;
                }

                if (list.Count == 0 && digits[i] == 0)
                {
                    continue;
                }

                list.Add(digits[i]);
                Backtrack();
                list.RemoveAt(list.Count - 1);
                indicesSet.Remove(i);
            }
        }
    }

    private static bool IsPowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;

    private static int[] GetDigits(int n)
    {
        var digits = new List<int>();
        while (n > 0)
        {
            digits.Add(n % 10);
            n /= 10;
        }
        return digits.ToArray();
    }
}
