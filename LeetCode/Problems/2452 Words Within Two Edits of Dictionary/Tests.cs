using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2452_Words_Within_Two_Edits_of_Dictionary;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TwoEditWords(testCase.Queries, testCase.Dictionary), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Queries { get; [UsedImplicitly] init; } = null!;
        public string[] Dictionary { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
