using JetBrains.Annotations;

namespace LeetCode._0911_Online_Election;

[PublicAPI]
public interface ISolution
{
    public ITopVotedCandidate Create(int[] persons, int[] times);
}
