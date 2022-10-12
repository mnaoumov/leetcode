﻿using System.Text.RegularExpressions;

namespace LeetCode._0065_Valid_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/819587393/
/// </summary>
public class Solution1 : ISolution
{
    public bool IsNumber(string s) => Regex.IsMatch(s, @"^[+-]?(\d+(\.\d*)?|\.\d+)([eE][+-]?\d+)?$");
}