namespace LeetCode.Problems._3814_Maximum_Capacity_Within_Budget;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-485/problems/maximum-capacity-within-budget/submissions/1888467250/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxCapacity(int[] costs, int[] capacity, int budget)
    {
        var n = costs.Length;

        var machines = new List<Machine>();

        for (var i = 0; i < n; i++)
        {
            machines.Add(new Machine(i, costs[i], capacity[i]));
        }

        var costMaxCapacityMap = new Dictionary<int, PriorityQueue<Machine, int>>();

        const int previousCost = 0;
        var pq = new PriorityQueue<Machine, int>();
        var sortedCosts = new List<int>();

        foreach (var machine in machines.OrderBy(m => m.Cost))
        {
            if (machine.Cost != previousCost)
            {
                pq = new PriorityQueue<Machine, int>(pq.UnorderedItems);
                costMaxCapacityMap[machine.Cost] = pq;
                sortedCosts.Add(machine.Cost);
            }
            pq.Enqueue(machine, machine.Capacity);

            if (pq.Count > 2)
            {
                pq.Dequeue();
            }
        }

        var ans = 0;

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var cost in sortedCosts)
        {
            if (cost >= budget)
            {
                break;
            }

            foreach (var (machine1, _) in costMaxCapacityMap[cost].UnorderedItems)
            {
                ans = Math.Max(ans, machine1.Capacity);
            }

            var restCost = budget - 1 - cost;
            var index = sortedCosts.BinarySearch(restCost);
            if (index < 0)
            {
                index = ~index - 1;
            }

            if (index < 0)
            {
                continue;
            }

            restCost = sortedCosts[index];

            foreach (var (machine1, _) in costMaxCapacityMap[cost].UnorderedItems)
            {
                foreach (var (machine2, _) in costMaxCapacityMap[restCost].UnorderedItems)
                {
                    if (machine1.Id == machine2.Id)
                    {
                        continue;
                    }

                    ans = Math.Max(ans, machine1.Capacity + machine2.Capacity);
                }
            }
        }

        return ans;
    }

    private record Machine(int Id, int Cost, int Capacity);
}
