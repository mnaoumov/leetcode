using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ser = solution.Create();
        var deser = solution.Create();
        var root = TreeNode.Create(testCase.Values);
        var ans = deser.deserialize(ser.serialize(root));
        Assert.That(ans, Is.EqualTo(root));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
    }
}