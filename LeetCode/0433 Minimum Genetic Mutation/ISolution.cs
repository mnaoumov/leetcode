using JetBrains.Annotations;

namespace LeetCode._0433_Minimum_Genetic_Mutation;

[PublicAPI]
public interface ISolution
{
    public int MinMutation(string start, string end, string[] bank);
}
