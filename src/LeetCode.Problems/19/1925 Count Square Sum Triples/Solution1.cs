namespace LeetCode.Problems._1925_Count_Square_Sum_Triples;

/// <seealso href="https://leetcode.com/problems/count-square-sum-triples/submissions/1849682423/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountTriples(int n)
    {
        var ans = 0;
        for (var a = 1; a <= n; a++)
        {
            for (var b = 1; b <= n; b++)
            {
                var s = a * a + b * b;
                var c = (int) Math.Sqrt(s);

                if (c > n)
                {
                    continue;
                }

                if (s == c * c)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
