﻿namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200571563/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution07 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache07(capacity);
    }
}