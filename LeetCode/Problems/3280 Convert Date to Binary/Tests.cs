using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3280_Convert_Date_to_Binary;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ConvertDateToBinary(testCase.Date), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Date { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
