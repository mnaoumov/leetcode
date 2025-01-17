namespace LeetCode.Problems._3408_Design_Task_Manager;

[PublicAPI]
public interface ITaskManager
{
    public void Add(int userId, int taskId, int priority);
    public void Edit(int taskId, int newPriority);
    public void Rmv(int taskId);
    public int ExecTop();
}
