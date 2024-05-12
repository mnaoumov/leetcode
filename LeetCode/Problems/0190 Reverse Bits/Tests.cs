using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0190_Reverse_Bits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var n = Convert.ToUInt32(testCase.N, 2);
        var output = Convert.ToUInt32(testCase.Output, 2);
        Assert.That(solution.reverseBits(n), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public string N { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
