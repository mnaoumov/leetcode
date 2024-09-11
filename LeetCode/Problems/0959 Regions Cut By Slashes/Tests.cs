using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0959_Regions_Cut_By_Slashes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RegionsBySlashes(testCase.Grid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Grid { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
