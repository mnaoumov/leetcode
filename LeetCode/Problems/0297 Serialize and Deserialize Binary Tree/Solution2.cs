namespace LeetCode.Problems._0297_Serialize_and_Deserialize_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/875920462/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public ICodec Create()
    {
        return new Codec2();
    }
}
