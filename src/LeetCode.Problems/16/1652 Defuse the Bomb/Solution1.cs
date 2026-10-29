namespace LeetCode.Problems._1652_Defuse_the_Bomb;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] Decrypt(int[] code, int k)
    {
        var n = code.Length;
        var ans = new int[n];

        if (k == 0)
        {
            return ans;
        }

        var isNegative = k < 0;

        if (isNegative)
        {
            code = code.Reverse().ToArray();
            k = -k;
        }

        var sum = 0;

        for (var j = 1; j <= k; j++)
        {
            sum += code[j];
        }

        ans[0] = sum;

        for (var i = 1; i < n; i++)
        {
            sum -= code[i];
            sum += code[(i + k) % n];
            ans[i] = sum;
        }

        if (isNegative)
        {
            ans = ans.Reverse().ToArray();
        }

        return ans;
    }
}
