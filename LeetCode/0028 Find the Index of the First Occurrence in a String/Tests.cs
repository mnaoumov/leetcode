using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0028_Find_the_Index_of_the_First_Occurrence_in_a_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.StrStr(testCase.HayStack, testCase.Needle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string HayStack { get; [UsedImplicitly] init; } = null!;
        public string Needle { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
