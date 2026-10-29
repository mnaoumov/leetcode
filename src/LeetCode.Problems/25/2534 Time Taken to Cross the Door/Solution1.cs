namespace LeetCode.Problems._2534_Time_Taken_to_Cross_the_Door;

/// <summary>
/// https://leetcode.com/submissions/detail/881008805/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] TimeTaken(int[] arrival, int[] state)
    {
        var stateQueues = new[] { new Queue<int>(), new Queue<int>() };

        var n = arrival.Length;

        var result = new int[n];
        var lastDoorUsedTime = -2;
        var lastDoorUsedState = 0;

        var index = 0;
        var time = 0;

        while (true)
        {
            while (index < n && arrival[index] == time)
            {
                var personState = state[index];
                var queue = stateQueues[personState];
                queue.Enqueue(index);
                index++;
            }

            int preferredPersonState;
            int anotherState;

            if (time > lastDoorUsedTime + 1 || lastDoorUsedState == 1)
            {
                preferredPersonState = 1;
                anotherState = 0;
            }
            else
            {
                preferredPersonState = 0;
                anotherState = 1;
            }

            var nextQueue = stateQueues[preferredPersonState];
            var nextState = preferredPersonState;

            if (nextQueue.Count == 0)
            {
                nextQueue = stateQueues[anotherState];
                nextState = anotherState;
            }

            if (nextQueue.Count > 0)
            {
                lastDoorUsedState = nextState;
                lastDoorUsedTime = time;
                var personIndex = nextQueue.Dequeue();
                result[personIndex] = time;
                time++;
            }
            else if (index < n)
            {
                time = arrival[index];
            }
            else
            {
                break;
            }
        }

        return result;
    }
}
