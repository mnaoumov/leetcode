namespace LeetCode.Problems._2590_Design_a_Todo_List;

[PublicAPI]
public interface ITodoList
{
    int AddTask(int userId, string taskDescription, int dueDate, IList<string> tags);
    IList<string> GetAllTasks(int userId);
    IList<string> GetTasksForTag(int userId, string tag);
    void CompleteTask(int userId, int taskId);
}
