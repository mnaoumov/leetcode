using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0383_Ransom_Note;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanConstruct(testCase.RansomNote, testCase.Magazine), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string RansomNote { get; [UsedImplicitly] init; } = null!;
        public string Magazine { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
