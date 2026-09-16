namespace LeetCode.Problems._1490_Clone_N_ary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var node = Node.CreateOrNull(testCase.Root);
        var cloned = solution.CloneTree(node);

        if (node != null)
        {
            Assert.That(cloned, Is.Not.SameAs(node));
        }

        Assert.That(cloned, Is.EqualTo(node));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
    }
}
