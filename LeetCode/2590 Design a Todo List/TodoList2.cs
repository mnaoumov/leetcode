namespace LeetCode._2590_Design_a_Todo_List;

/// <summary>
/// https://leetcode.com/submissions/detail/917149915/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class TodoList2 : ITodoList
{
    private int _maxId;
    private readonly Dictionary<int, User> _users = new();
    private readonly Dictionary<int, Task> _tasks = new();

    public int AddTask(int userId, string taskDescription, int dueDate, IList<string> tags)
    {
        var user = GetUser(userId);

        if (user == User.Missing)
        {
            user = _users[userId] = new User();
        }

        _maxId++;
        var task = new Task(_maxId, taskDescription, dueDate, tags);
        _tasks[task.Id] = task;

        user.AddTask(task);
        return task.Id;
    }

    private User GetUser(int userId) => _users.GetValueOrDefault(userId, User.Missing);

    public IList<string> GetAllTasks(int userId) => GetUser(userId).GetTasks().OrderBy(task => task.DueDate)
        .Select(task => task.Description).ToArray();

    public IList<string> GetTasksForTag(int userId, string tag) => GetUser(userId).GetTasksForTag(tag)
        .OrderBy(task => task.DueDate).Select(task => task.Description).ToArray();

    public void CompleteTask(int userId, int taskId)
    {
        if (!_tasks.Remove(taskId, out var task))
        {
            return;
        }

        GetUser(userId).CompleteTask(task);
    }

    private class User
    {
        public static readonly User Missing = new();
        private readonly HashSet<Task> _tasks = new();
        private readonly Dictionary<string, HashSet<Task>> _tagTaskMap = new();

        public IEnumerable<Task> GetTasksForTag(string tag) => _tagTaskMap.GetValueOrDefault(tag, new HashSet<Task>());

        public void AddTask(Task task)
        {
            _tasks.Add(task);

            foreach (var tag in task.Tags)
            {
                if (!_tagTaskMap.ContainsKey(tag))
                {
                    _tagTaskMap[tag] = new HashSet<Task>();
                }

                _tagTaskMap[tag].Add(task);
            }
        }

        public IEnumerable<Task> GetTasks() => _tasks;

        public void CompleteTask(Task task)
        {
            if (!_tasks.Remove(task))
            {
                return;
            }

            foreach (var tag in task.Tags)
            {
                _tagTaskMap[tag].Remove(task);
            }
        }
    }

    private record Task(int Id, string Description, int DueDate, IList<string> Tags);
}
