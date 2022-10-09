namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200414974/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution02 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache02(capacity);
    }
}