namespace LeetCode.Problems._1942_The_Number_of_the_Smallest_Unoccupied_Chair;

/// <summary>
/// https://leetcode.com/submissions/detail/1418659683/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestChair(int[][] times, int targetFriend)
    {
        var availableChairs = new SortedSet<int>();
        var usedChairsCount = 0;
        var n = times.Length;
        var chairsMap = new int[n];
        var pq = new PriorityQueue<(int time, bool isArriving, int friendIndex), (int time, bool isArriving)>();

        for (var friendIndex = 0; friendIndex < n; friendIndex++)
        {
            var time = times[friendIndex];
            var arrival = time[0];
            var leaving = time[1];
            pq.Enqueue((arrival, true, friendIndex), (arrival, true));
            pq.Enqueue((leaving, false, friendIndex), (leaving, false));
        }

        while (pq.Count > 0)
        {
            var (time, isArriving, friendIndex) = pq.Dequeue();

            if (isArriving)
            {
                if (availableChairs.Count == 0)
                {
                    chairsMap[friendIndex] = usedChairsCount;
                    usedChairsCount++;
                }
                else
                {
                    var chair = availableChairs.Min;
                    availableChairs.Remove(chair);
                    chairsMap[friendIndex] = chair;
                }

                if (friendIndex == targetFriend)
                {
                    return chairsMap[friendIndex];
                }
            }
            else
            {
                var chair = chairsMap[friendIndex];
                availableChairs.Add(chair);
            }
        }

        throw new InvalidOperationException();
    }
}
