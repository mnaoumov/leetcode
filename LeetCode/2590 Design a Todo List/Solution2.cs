using JetBrains.Annotations;

namespace LeetCode._2590_Design_a_Todo_List;

/// <summary>
/// https://leetcode.com/submissions/detail/917149915/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public ITodoList Create()
    {
        return new TodoList2();
    }
}
