using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2053_Kth_Distinct_String_in_an_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KthDistinct(testCase.Arr, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Arr { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
