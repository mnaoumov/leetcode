namespace LeetCode.Problems._1780_Check_if_Number_is_a_Sum_of_Powers_of_Three;

/// <summary>
/// https://leetcode.com/problems/check-if-number-is-a-sum-of-powers-of-three/submissions/1561987663/?envType=daily-question&envId=2025-03-04
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CheckPowersOfThree(int n)
    {
        if (n == 0)
        {
            return true;
        }

        var powerIndex3 = (int) Math.Floor(Math.Log(n, 3));
        var powerValue3 = (int) Math.Pow(3, powerIndex3);
        var rest = n - powerValue3;

        return rest < powerValue3 && CheckPowersOfThree(rest);
    }
}
