using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0278_First_Bad_Version;

[UsedImplicitly]
public class Tests : TestsBase<VersionControl, Tests.TestCase>
{
    protected override void TestImpl(VersionControl solution, TestCase testCase)
    {
        solution.SetFirstBadVersion(testCase.Bad);
        Assert.That(solution.FirstBadVersion(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Bad { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
