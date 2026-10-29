namespace LeetCode.Problems._1541_Minimum_Insertions_to_Balance_a_Parentheses_String;

/// <summary>
/// https://leetcode.com/problems/minimum-insertions-to-balance-a-parentheses-string/submissions/2166863572/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinInsertions(string s)
    {
        var balance = 0;
        var ans = 0;
        const char openBracket = '(';
        const char closedBracket = ')';
        var sequentialclosedBracketsCount = 0;

        foreach (var symbol in s)
        {
            switch (symbol)
            {
                case openBracket:
                    if (sequentialclosedBracketsCount % 2 == 1)
                    {
                        ans += 1;
                        balance -= 1;
                    }

                    sequentialclosedBracketsCount = 0;
                    balance += 2;
                    break;
                case closedBracket:
                    balance--;
                    sequentialclosedBracketsCount++;
                    break;
                default:
                    throw new InvalidOperationException($"Unknown symbol: {symbol}");
            }

            if (balance >= 0)
            {
                continue;
            }

            ans++;
            balance += 2;
        }

        ans += balance;

        return ans;
    }
}
