using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0726_Number_of_Atoms;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountOfAtoms(testCase.Formula), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Formula { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
