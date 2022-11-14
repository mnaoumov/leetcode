using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0067_Add_Binary;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddBinary(testCase.A, testCase.B), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string A { get; [UsedImplicitly] init; } = null!;
        public string B { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}