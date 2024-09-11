using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0547_Number_of_Provinces;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindCircleNum(testCase.IsConnected), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] IsConnected { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
