using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0623_Add_One_Row_to_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddOneRow(TreeNode.Create(testCase.ValuesBefore)!, testCase.Val, testCase.Depth),
            Is.EqualTo(TreeNode.Create(testCase.ValuesAfter)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] ValuesBefore { get; [UsedImplicitly] init; } = null!;
        public int?[] ValuesAfter { get; [UsedImplicitly] init; } = null!;
        public int Val { get; [UsedImplicitly] init; }
        public int Depth { get; [UsedImplicitly] init; }
    }
}