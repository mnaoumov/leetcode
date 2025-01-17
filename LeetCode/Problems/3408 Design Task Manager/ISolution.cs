namespace LeetCode.Problems._3408_Design_Task_Manager;

[PublicAPI]
public interface ISolution
{
    public ITaskManager Create(IList<IList<int>> tasks);
}
