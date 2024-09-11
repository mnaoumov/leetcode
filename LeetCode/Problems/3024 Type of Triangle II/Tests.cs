using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3024_Type_of_Triangle_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TriangleType(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
