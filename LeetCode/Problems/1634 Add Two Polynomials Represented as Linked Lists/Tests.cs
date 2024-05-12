using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1634_Add_Two_Polynomials_Represented_as_Linked_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddPoly(PolyNode.CreateOrNull(testCase.Poly1), PolyNode.CreateOrNull(testCase.Poly2)), Is.EqualTo(PolyNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Poly1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Poly2 { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
