// ReSharper disable All
using JetBrains.Annotations;

namespace LeetCode._0502_IPO;

/// <summary>
/// https://leetcode.com/submissions/detail/208735862/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital)
    {
        var companyCapital = W;
        var n = Capital.Length;
        var projectsTakenIndices = new HashSet<int>();
        var projects = new List<Project>();

        for (int i = 0; i < n; i++)
        {
            projects.Add(new Project
            {
                Capital = Capital[i],
                Profit = Profits[i]
            });
        }

        projects = projects.OrderByDescending(p => p.Profit).ThenBy(p => p.Capital).ToList();

        for (int i = 0; i < k; i++)
        {
            var found = false;

            for (int j = 0; j < projects.Count; j++)
            {
                var project = projects[j];
                if (project.Capital <= companyCapital)
                {
                    companyCapital += project.Profit;
                    projects.RemoveAt(j);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                break;
            }
        }

        return companyCapital;
    }

    private struct Project
    {
        public int Capital;
        public int Profit;
    }
}
