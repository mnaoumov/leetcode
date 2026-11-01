namespace LeetCode.Problems._2546_Apply_Bitwise_Operations_to_Make_Strings_Equal;

/// <seealso href="https://leetcode.com/contest/weekly-contest-329/submissions/detail/882783895/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool MakeStringsEqual(string s, string target) => s == target || s.Any(symbol => symbol == '1') && target.Any(symbol => symbol == '1');
}
