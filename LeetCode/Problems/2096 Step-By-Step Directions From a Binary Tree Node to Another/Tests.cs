using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2096_Step_By_Step_Directions_From_a_Binary_Tree_Node_to_Another;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetDirections(TreeNode.Create(testCase.Root), testCase.StartValue, testCase.DestValue), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int StartValue { get; [UsedImplicitly] init; }
        public int DestValue { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
