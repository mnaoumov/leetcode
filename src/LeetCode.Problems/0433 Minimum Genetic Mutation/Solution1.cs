namespace LeetCode.Problems._0433_Minimum_Genetic_Mutation;

/// <summary>
/// https://leetcode.com/submissions/detail/835054128/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        const int impossible = -1;

        var isEndInBank = false;

        var mutationsDict = new Dictionary<string, HashSet<string>>();

        foreach (var gene in new[] { start }.Concat(bank))
        {
            mutationsDict[gene] = new HashSet<string>();
        }

        for (var i = 0; i < bank.Length; i++)
        {
            if (bank[i] == end)
            {
                isEndInBank = true;
            }

            if (CanMutate(start, bank[i]))
            {
                mutationsDict[start].Add(bank[i]);
            }

            for (var j = i + 1; j < bank.Length; j++)
            {
                if (!CanMutate(bank[i], bank[j]))
                {
                    continue;
                }

                mutationsDict[bank[i]].Add(bank[j]);
                mutationsDict[bank[j]].Add(bank[i]);
            }
        }

        if (!isEndInBank)
        {
            return impossible;
        }

        if (start == end)
        {
            return 0;
        }

        var visited = new HashSet<string>();

        return Dfs(start);

        int Dfs(string gene)
        {
            if (gene == end)
            {
                return 0;
            }

            if (!visited.Add(gene))
            {
                return impossible;
            }

            var result = mutationsDict[gene].Select(Dfs).Where(x => x != impossible).DefaultIfEmpty(impossible - 1).Min() + 1;
            visited.Remove(gene);

            return result;
        }
    }

    private static bool CanMutate(string gene1, string gene2)
    {
        var diffCount = 0;
        for (var i = 0; i < gene1.Length; i++)
        {
            if (gene1[i] == gene2[i])
            {
                continue;
            }

            diffCount++;

            if (diffCount > 1)
            {
                break;
            }
        }

        return diffCount == 1;
    }
}
