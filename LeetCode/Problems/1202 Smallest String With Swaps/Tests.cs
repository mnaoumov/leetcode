using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1202_Smallest_String_With_Swaps;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestStringWithSwaps(testCase.S, testCase.Pairs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Pairs { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
