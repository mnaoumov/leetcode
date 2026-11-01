namespace LeetCode.Problems._0297_Serialize_and_Deserialize_Binary_Tree;

/// <seealso href="https://leetcode.com/submissions/detail/199799092/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICodec Create()
    {
        return new Codec1();
    }
}
