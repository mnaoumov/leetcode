using JetBrains.Annotations;

namespace LeetCode.Problems._0502_IPO;

/// <summary>
/// https://leetcode.com/submissions/detail/895964459/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
    {
        var pq = new PriorityQueue<Project, (int negativeProfit, int capital)>();

        var n = profits.Length;

        for (var i = 0; i < n; i++)
        {
            EnqueueProject(new Project(profits[i], capital[i]));
        }

        var projectCountAvailable = k;
        var capitalAvailable = w;
        var skippedProjects = new List<Project>();

        while (pq.Count > 0)
        {
            var project = pq.Dequeue();

            if (project.CapitalRequired <= capitalAvailable)
            {
                capitalAvailable += project.Profit;
                projectCountAvailable--;

                if (projectCountAvailable == 0)
                {
                    break;
                }

                foreach (var skippedProject in skippedProjects)
                {
                    EnqueueProject(skippedProject);
                }

                skippedProjects.Clear();
            }
            else
            {
                skippedProjects.Add(project);
            }
        }

        return capitalAvailable;

        void EnqueueProject(Project project) => pq.Enqueue(project, (-project.Profit, project.CapitalRequired));
    }

    private record Project(int Profit, int CapitalRequired);
}
