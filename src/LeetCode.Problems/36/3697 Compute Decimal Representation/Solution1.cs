namespace LeetCode.Problems._3697_Compute_Decimal_Representation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-469/problems/compute-decimal-representation/submissions/1784770372/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] DecimalRepresentation(int n)
    {
        var list = new List<int>();
        var powerOfTen = 1;

        while (n > 0)
        {
            var digit = n % 10;

            if (digit > 0)
            {
                list.Insert(0, digit * powerOfTen);
            }
            n /= 10;
            powerOfTen *= 10;
        }

        return list.ToArray();
    }
}
