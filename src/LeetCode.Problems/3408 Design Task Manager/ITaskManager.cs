namespace LeetCode.Problems._3408_Design_Task_Manager;

[PublicAPI]
public interface ITaskManager
{
    void Add(int userId, int taskId, int priority);
    void Edit(int taskId, int newPriority);
    void Rmv(int taskId);
    int ExecTop();
}
