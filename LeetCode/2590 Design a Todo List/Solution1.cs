using JetBrains.Annotations;

namespace LeetCode._2590_Design_a_Todo_List;

/// <summary>
/// https://leetcode.com/submissions/detail/917141764/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ITodoList Create()
    {
        return new TodoList1();
    }
}
