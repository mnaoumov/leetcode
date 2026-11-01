namespace LeetCode.Problems._1295_Find_Numbers_with_Even_Number_of_Digits;

/// <seealso href="TODO url">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindNumbers(int[] nums) => nums.Count(num => num.ToString().Length % 2 == 0);
}
