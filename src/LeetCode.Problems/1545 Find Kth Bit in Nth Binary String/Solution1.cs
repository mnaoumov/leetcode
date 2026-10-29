namespace LeetCode.Problems._1545_Find_Kth_Bit_in_Nth_Binary_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1426881155/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char FindKthBit(int n, int k) => S(n)[k - 1];

    private static string S(int n)
    {
        if (n == 1)
        {
            return "0";
        }

        var prev = S(n - 1);
        return prev + "1" + Reverse(Invert(prev));
    }

    private static string Invert(string str) => string.Concat(str.ToCharArray().Select(Invert2));

    private static char Invert2(char symbol) =>
        symbol switch
        {
            '0' => '1',
            '1' => '0',
            _ => symbol
        };

    private static string Reverse(string str) => string.Concat(str.ToCharArray().Reverse());
}
