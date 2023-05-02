using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0006_Zigzag_Conversion;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Convert(testCase.String, testCase.NumRows), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string String { get; [UsedImplicitly] init; } = null!;
        public int NumRows { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
