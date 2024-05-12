using JetBrains.Annotations;

namespace LeetCode.Problems._2590_Design_a_Todo_List;

/// <summary>
/// https://leetcode.com/submissions/detail/917141764/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ITodoList Create() => new TodoList();

    private class TodoList : ITodoList
    {
        private readonly Dictionary<int, User> _users = new();

        public int AddTask(int userId, string taskDescription, int dueDate, IList<string> tags)
        {
            var user = GetUser(userId);

            if (user == User.Missing)
            {
                user = _users[userId] = new User();
            }

            var task = new Task(taskDescription, dueDate, tags);
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
            var task = Task.Remove(taskId);

            if (task == null)
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

        private class Task
        {
            public Task(string description, int dueDate, IList<string> tags)
            {
                _maxId++;
                Id = _maxId;
                Description = description;
                DueDate = dueDate;
                Tags = tags;
                IdMap[_maxId] = this;
            }

            private static int _maxId;
            private static readonly Dictionary<int, Task> IdMap = new();

            public IList<string> Tags { get; }
            public string Description { get; }
            public int DueDate { get; }
            public int Id { get; }

            public static Task? Remove(int taskId) => IdMap.Remove(taskId, out var task) ? task : null;
        }
    }
}
