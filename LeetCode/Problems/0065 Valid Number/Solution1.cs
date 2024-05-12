using System.Text.RegularExpressions;

using JetBrains.Annotations;

namespace LeetCode._0065_Valid_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/819587393/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
    public bool IsNumber(string s) => Regex.IsMatch(s, @"^[+-]?(\d+(\.\d*)?|\.\d+)([eE][+-]?\d+)?$");
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
}
