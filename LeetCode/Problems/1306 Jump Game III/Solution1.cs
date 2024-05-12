using JetBrains.Annotations;

namespace LeetCode.Problems._1306_Jump_Game_III;

/// <summary>
/// https://leetcode.com/submissions/detail/898108323/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanReach(int[] arr, int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var index = queue.Dequeue();

            if (index < 0 || index >= arr.Length)
            {
                continue;
            }

            if (!visited.Add(index))
            {
                continue;
            }

            if (arr[index] == 0)
            {
                return true;
            }

            queue.Enqueue(index + arr[index]);
            queue.Enqueue(index - arr[index]);
        }

        return false;
    }
}
