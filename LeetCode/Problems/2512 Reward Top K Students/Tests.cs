
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2512_Reward_Top_K_Students;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.TopStudents(testCase.Positive_feedback, testCase.Negative_feedback, testCase.Report, testCase.Student_id, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        // ReSharper disable once InconsistentNaming
        public string[] Positive_feedback { get; [UsedImplicitly] init; } = null!;
        // ReSharper disable once InconsistentNaming
        public string[] Negative_feedback { get; [UsedImplicitly] init; } = null!;
        public string[] Report { get; [UsedImplicitly] init; } = null!;
        // ReSharper disable once InconsistentNaming
        public int[] Student_id { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
