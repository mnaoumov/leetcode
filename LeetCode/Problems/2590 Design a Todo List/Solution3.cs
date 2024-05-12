using JetBrains.Annotations;

namespace LeetCode._2590_Design_a_Todo_List;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ITodoList Create() => new TodoList();

    private class TodoList : ITodoList
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
            var task = _tasks.GetValueOrDefault(taskId);

            if (task == null)
            {
                return;
            }

            if (GetUser(userId).CompleteTask(task))
            {
                _tasks.Remove(taskId);
            }
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

            public bool CompleteTask(Task task)
            {
                if (!_tasks.Remove(task))
                {
                    return false;
                }

                foreach (var tag in task.Tags)
                {
                    _tagTaskMap[tag].Remove(task);
                }

                return true;
            }
        }

        private record Task(int Id, string Description, int DueDate, IList<string> Tags);
    }
}
