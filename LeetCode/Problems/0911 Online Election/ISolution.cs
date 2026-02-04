namespace LeetCode.Problems._0911_Online_Election;

[PublicAPI]
public interface ISolution
{
    ITopVotedCandidate Create(int[] persons, int[] times);
}
