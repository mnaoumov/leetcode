using JetBrains.Annotations;

namespace LeetCode._1606_Find_Servers_That_Handled_Most_Number_of_Requests;

/// <summary>
/// https://leetcode.com/submissions/detail/958079941/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> BusiestServers(int k, int[] arrival, int[] load)
    {
        var availableServers = new SortedSet<int?>();

        for (var i = 0; i < k; i++)
        {
            availableServers.Add(i);
        }

        var endTimes = new PriorityQueue<(int serverIndex, int endTime), int>();

        var ans = new List<int>();

        var requestCounts = new int[k];
        var maxCount = 0;

        for (var i = 0; i < arrival.Length; i++)
        {
            var requestTime = arrival[i];
            int serverIndex;

            while (endTimes.Count > 0 && endTimes.Peek().endTime <= requestTime)
            {
                (serverIndex, _) = endTimes.Dequeue();
                availableServers.Add(serverIndex);
            }

            if (availableServers.Count == 0)
            {
                continue;
            }

            var top = availableServers.GetViewBetween(i % k, k);

            serverIndex = top.Min ?? (int) availableServers.Min!;

            requestCounts[serverIndex]++;
            var endTime = requestTime + load[i];
            endTimes.Enqueue((serverIndex, endTime), endTime);
            availableServers.Remove(serverIndex);

            if (requestCounts[serverIndex] > maxCount)
            {
                ans.Clear();
                maxCount = requestCounts[serverIndex];
            }

            if (requestCounts[serverIndex] == maxCount)
            {
                ans.Add(serverIndex);
            }
        }

        return ans;
    }
}
