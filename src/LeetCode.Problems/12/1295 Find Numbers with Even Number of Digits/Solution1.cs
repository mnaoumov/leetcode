namespace LeetCode.Problems._1295_Find_Numbers_with_Even_Number_of_Digits;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindNumbers(int[] nums) => nums.Count(num => num.ToString().Length % 2 == 0);
}
