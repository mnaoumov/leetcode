
using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2178_Maximum_Split_of_Positive_Even_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var result = solution.MaximumEvenSplit(testCase.FinalSum);
        Assert.That(result, Has.Count.EqualTo(testCase.OutputLength));
        Assert.That(result, Is.Unique);
        Assert.That(result, Has.All.Matches<long>(num => num % 2 == 0));

        if (testCase.FinalSum % 2 == 0)
        {
            Assert.That(result.Sum(), Is.EqualTo(testCase.FinalSum));
        }
        else
        {
            Assert.That(result, Is.Empty);
        }
    }

    public class TestCase : TestCaseBase
    {
        public long FinalSum { get; [UsedImplicitly] init; }
        public int OutputLength { get; [UsedImplicitly] init; }
    }
}
