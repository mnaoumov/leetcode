using JetBrains.Annotations;

namespace LeetCode._0911_Online_Election;

[PublicAPI]
public interface ITopVotedCandidate
{
    public int Q(int t);
}
