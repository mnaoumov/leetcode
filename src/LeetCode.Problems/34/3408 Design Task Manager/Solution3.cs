namespace LeetCode.Problems._3408_Design_Task_Manager;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-147/submissions/detail/1497460752/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public ITaskManager Create(IList<IList<int>> tasks) => new TaskManager(tasks);

    private class TaskManager : ITaskManager
    {
        private readonly Dictionary<int, int> _taskIdPriorityMap = new();
        private readonly Dictionary<int, int> _taskIdUserMap = new();
        private readonly SortedSet<(int inversePriority, int inverseTaskId)> _sortedPairs = new();


        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
            {
                Add(task[0], task[1], task[2]);
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            _sortedPairs.Add((-priority, -taskId));
            _taskIdPriorityMap[taskId] = priority;
            _taskIdUserMap[taskId] = userId;
        }

        public void Edit(int taskId, int newPriority)
        {
            var storedPriority = _taskIdPriorityMap[taskId];
            _sortedPairs.Remove((-storedPriority, -taskId));
            _sortedPairs.Add((-newPriority, -taskId));
            _taskIdPriorityMap[taskId] = newPriority;
        }

        public void Rmv(int taskId)
        {
            var storedPriority = _taskIdPriorityMap[taskId];
            _sortedPairs.Remove((-storedPriority, -taskId));
            _taskIdUserMap.Remove(taskId);
            _taskIdPriorityMap.Remove(taskId);
        }

        public int ExecTop()
        {
            if (_sortedPairs.Count == 0)
            {
                return -1;
            }

            var (_, inverseTaskId) = _sortedPairs.Min;
            var taskId = -inverseTaskId;
            var userId = _taskIdUserMap[taskId];
            Rmv(taskId);
            return userId;
        }
    }
}
