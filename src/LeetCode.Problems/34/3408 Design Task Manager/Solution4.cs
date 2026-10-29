namespace LeetCode.Problems._3408_Design_Task_Manager;

/// <summary>
/// https://leetcode.com/problems/design-task-manager/submissions/1774534266/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public ITaskManager Create(IList<IList<int>> tasks) => new TaskManager(tasks);

    private class TaskManager : ITaskManager
    {
        private readonly Dictionary<int, int> _taskIdPriorityMap = new();
        private readonly Dictionary<int, int> _taskIdUserMap = new();
        private readonly PriorityQueue<(int priority, int taskId), (int inversePriority, int inverseTaskId)> _pq = new();

        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
            {
                Add(task[0], task[1], task[2]);
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            _pq.Enqueue((priority, taskId), (-priority, -taskId));
            _taskIdPriorityMap[taskId] = priority;
            _taskIdUserMap[taskId] = userId;
        }

        public void Edit(int taskId, int newPriority)
        {
            _pq.Enqueue((newPriority, taskId), (-newPriority, -taskId));
            _taskIdPriorityMap[taskId] = newPriority;
        }

        public void Rmv(int taskId)
        {
            _taskIdUserMap.Remove(taskId);
            _taskIdPriorityMap.Remove(taskId);
        }

        public int ExecTop()
        {
            while (true)
            {
                if (_pq.Count == 0)
                {
                    return -1;
                }

                var (priority, taskId) = _pq.Dequeue();

                if (_taskIdPriorityMap.GetValueOrDefault(taskId, -1) != priority)
                {
                    continue;
                }

                var userId = _taskIdUserMap[taskId];
                Rmv(taskId);
                return userId;
            }
        }
    }
}
