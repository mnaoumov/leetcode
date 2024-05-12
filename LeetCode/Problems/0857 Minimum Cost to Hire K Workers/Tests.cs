using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0857_Minimum_Cost_to_Hire_K_Workers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MincostToHireWorkers(testCase.Quality, testCase.Wage, testCase.K),
            Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Quality { get; [UsedImplicitly] init; } = null!;
        public int[] Wage { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
