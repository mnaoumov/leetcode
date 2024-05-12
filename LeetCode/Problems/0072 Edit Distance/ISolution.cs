using JetBrains.Annotations;

namespace LeetCode.Problems._0072_Edit_Distance;

[PublicAPI]
public interface ISolution
{
    public int MinDistance(string word1, string word2);
}
