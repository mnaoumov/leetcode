using JetBrains.Annotations;

namespace LeetCode.Problems._2590_Design_a_Todo_List;

[PublicAPI]
public interface ITodoList
{
    public int AddTask(int userId, string taskDescription, int dueDate, IList<string> tags);
    public IList<string> GetAllTasks(int userId);
    public IList<string> GetTasksForTag(int userId, string tag);
    public void CompleteTask(int userId, int taskId);
}
