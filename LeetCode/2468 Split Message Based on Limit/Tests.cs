using JetBrains.Annotations;

namespace LeetCode._2468_Split_Message_Based_on_Limit;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SplitMessage(testCase.Message, testCase.Limit), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Message { get; [UsedImplicitly] init; } = null!;
        public int Limit { get; [UsedImplicitly] init; }
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}