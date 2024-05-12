using JetBrains.Annotations;

namespace LeetCode._2550_Count_Collisions_of_Monkeys_on_a_Polygon;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887168649/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    private const int Modulo = 1_000_000_007;
    public int MonkeyMove(int n) => (Modulo + Pow2(n) - 2) % Modulo;

    private static int Pow2(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        var powHalf = Pow2(n / 2);
        return (int) (1L * powHalf * powHalf * (n % 2 == 1 ? 2 : 1) % Modulo);
    }
}
