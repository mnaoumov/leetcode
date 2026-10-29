namespace LeetCode.Problems._2983_Palindrome_Rearrangement_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/1132723896/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool[] CanMakePalindromeQueries(string s, int[][] queries)
    {
        var n = s.Length;
        var m = n / 2;
        var left = s[..m];
        var rightReversed = string.Concat(Enumerable.Range(0, m).Select(i => s[^(i + 1)]));

        var prefixLength = 0;

        for (var i = 0; i < m; i++)
        {
            if (left[i] != rightReversed[i])
            {
                break;
            }

            prefixLength++;
        }

        var suffixLength = 0;

        for (var i = m - 1; i >= 0; i--)
        {
            if (left[i] != rightReversed[i])
            {
                break;
            }

            suffixLength++;
        }

        return queries.Select(Test).ToArray();

        bool Test(int[] query)
        {
            var a1 = query[0];
            var b1 = query[1];
            var c1 = query[2];
            var d1 = query[3];

            var a2 = n - 1 - d1;
            var b2 = n - 1 - c1;

            var s1 = left;
            var s2 = rightReversed;

            if (a2 < a1)
            {
                (a1, b1, s1, a2, b2, s2) = (a2, b2, s2, a1, b1, s1);
            }

            if (a1 > prefixLength)
            {
                return false;
            }

            if (m - 1 - Math.Max(b1, b2) > suffixLength)
            {
                return false;
            }

            if (b2 <= b1)
            {
                return TestWithoutOrder(a1, b1);
            }

            if (a2 <= b1)
            {
                return TestWithoutOrder(a1, b2);
            }

            if (s1[(b1 + 1)..a2] != s2[(b1 + 1)..a2])
            {
                return false;
            }

            return TestWithoutOrder(a1, b1) && TestWithoutOrder(a2, b2);

        }

        bool TestWithoutOrder(int a, int b)
        {
            var c1 = left[a..(b + 1)].ToCharArray().OrderBy(c => c);
            var c2 = rightReversed[a..(b + 1)].ToCharArray().OrderBy(c => c);
            return c1.SequenceEqual(c2);
        }
    }
}
