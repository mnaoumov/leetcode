using System.Text.RegularExpressions;

namespace LeetCode.Problems._0065_Valid_Number;

/// <seealso href="https://leetcode.com/submissions/detail/819587393/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    public bool IsNumber(string s) => Regex.IsMatch(s, @"^[+-]?(\d+(\.\d*)?|\.\d+)([eE][+-]?\d+)?$");
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
}
