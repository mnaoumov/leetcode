using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3091_Apply_Operations_to_Make_Sum_of_Array_Greater_Than_or_Equal_to_k;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinOperations(testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
