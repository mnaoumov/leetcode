namespace LeetCode.Problems._3783_Mirror_Distance_of_an_Integer;

/// <summary>
/// https://leetcode.com/problems/mirror-distance-of-an-integer/submissions/1982127482/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MirrorDistance(int n) => Math.Abs(n - Reverse(n));

    private static int Reverse(int num) => Digits(num).Aggregate(0, (current, digit) => 10 * current + digit);

    private static List<int> Digits(int num)
    {
        var ans = new List<int>();

        while (num > 0)
        {
            var digit = num % 10;
            ans.Add(digit);
            num /= 10;
        }

        return ans;
    }
}
