using JetBrains.Annotations;

namespace LeetCode._0692_Top_K_Frequent_Words;

[PublicAPI]
public interface ISolution
{
    public IList<string> TopKFrequent(string[] words, int k);
}