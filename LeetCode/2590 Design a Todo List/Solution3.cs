using JetBrains.Annotations;

namespace LeetCode._2590_Design_a_Todo_List;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ITodoList Create()
    {
        return new TodoList3();
    }
}
