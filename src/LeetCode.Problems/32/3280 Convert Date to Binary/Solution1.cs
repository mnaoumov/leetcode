namespace LeetCode.Problems._3280_Convert_Date_to_Binary;

/// <seealso href="https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382654578/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ConvertDateToBinary(string date) => string.Join('-', date.Split('-').Select(numStr => Convert.ToString(int.Parse(numStr), 2)));
}
