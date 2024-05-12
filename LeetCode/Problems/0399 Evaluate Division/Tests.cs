
using JetBrains.Annotations;

namespace LeetCode.Problems._0399_Evaluate_Division;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CalcEquation(testCase.Equations, testCase.Values, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Equations { get; [UsedImplicitly] init; } = null!;
        public double[] Values { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Queries { get; [UsedImplicitly] init; } = null!;
        public double[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
