namespace LeetCode._2443_Sum_of_Number_and_Its_Reverse;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-315/submissions/detail/823398063/
/// </summary>
public class Solution2 : ISolution
{
    public bool SumOfNumberAndReverse(int num)
    {
        if (num == 0)
        {
            return true;
        }

        for (var i = 1; i < num; i++)
        {
            if (i + Reverse(i) == num)
            {
                return true;
            }
        }

        return false;
    }

    private static int Reverse(int i) => int.Parse(new string(i.ToString().Reverse().ToArray()));
}