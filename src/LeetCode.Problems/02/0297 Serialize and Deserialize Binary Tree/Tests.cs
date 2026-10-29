namespace LeetCode.Problems._0297_Serialize_and_Deserialize_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var ser = solution.Create();
        var deser = solution.Create();
        var root = TreeNode.CreateOrNull(testCase.Values);
        var ans = deser.deserialize(ser.serialize(root));
        Assert.That(ans, Is.EqualTo(root));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
    }
}
