namespace LeetCode.Problems._0779_K_th_Symbol_in_Grammar;

/// <summary>
/// https://leetcode.com/submissions/detail/1083494577/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int KthGrammar(int n, int k)
    {
        while (n > 1)
        {
            var middle = 1 << n - 2;

            if (k > middle)
            {
                return 1 - KthGrammar(n - 1, k - middle);
            }

            n--;
        }

        return 0;
    }
}
