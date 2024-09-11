using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0433_Minimum_Genetic_Mutation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMutation(testCase.Start, testCase.End, testCase.Bank), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Start { get; [UsedImplicitly] init; } = null!;
        public string End { get; [UsedImplicitly] init; } = null!;
        public string[] Bank { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
