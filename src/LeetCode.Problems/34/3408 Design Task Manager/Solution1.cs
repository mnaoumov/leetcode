namespace LeetCode.Problems._3408_Design_Task_Manager;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-147/submissions/detail/1497435909/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public ITaskManager Create(IList<IList<int>> tasks) => new TaskManager(tasks);

    private class TaskManager : ITaskManager
    {
        private readonly PriorityQueue<(int taskId, int priority), (int inversePriority, int inverseTaskId)> _taskPriorityQueue = new();
        private readonly Dictionary<int, int> _taskIdPriorityMap = new();
        private readonly Dictionary<int, int> _taskIdUserMap = new();


        public TaskManager(IList<IList<int>> tasks)
        {
            foreach (var task in tasks)
            {
                Add(task[0], task[1], task[2]);
            }
        }

        public void Add(int userId, int taskId, int priority)
        {
            _taskPriorityQueue.Enqueue((taskId, priority), (-priority, -taskId));
            _taskIdPriorityMap[taskId] = priority;
            _taskIdUserMap[taskId] = userId;
        }

        public void Edit(int taskId, int newPriority)
        {
            _taskPriorityQueue.Enqueue((taskId, newPriority), (-newPriority, -taskId));
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
                var (taskId, priority) = _taskPriorityQueue.Dequeue();

                if (!_taskIdPriorityMap.TryGetValue(taskId, out var storedPriority) || storedPriority != priority)
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
