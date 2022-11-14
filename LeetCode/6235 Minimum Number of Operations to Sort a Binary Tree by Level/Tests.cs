using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6235_Minimum_Number_of_Operations_to_Sort_a_Binary_Tree_by_Level;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumOperations(TreeNode.Create(testCase.RootValues)!), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}