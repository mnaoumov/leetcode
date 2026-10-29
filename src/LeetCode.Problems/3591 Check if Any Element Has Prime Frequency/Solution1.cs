namespace LeetCode.Problems._3591_Check_if_Any_Element_Has_Prime_Frequency;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-455/problems/check-if-any-element-has-prime-frequency/submissions/1672140510/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckPrimeFrequency(int[] nums) =>
        nums.GroupBy(num => num).Select(g => g.Count()).Distinct().Any(IsPrime);

    private static bool IsPrime(int num)
    {
        if (num == 1)
        {
            return false;
        }

        for (var i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
