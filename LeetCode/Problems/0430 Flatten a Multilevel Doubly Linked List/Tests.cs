using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0430_Flatten_a_Multilevel_Doubly_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Flatten(Node.CreateOrNull(testCase.Head)), Is.EqualTo(Node.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Head { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
