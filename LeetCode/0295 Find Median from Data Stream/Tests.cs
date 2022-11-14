using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0295_Find_Median_from_Data_Stream;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public Action<IMedianFinder> Test { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        sut.AddNum(1);
                        sut.AddNum(2);
                        Assert.That(sut.FindMedian(), Is.EqualTo(1.5));
                        sut.AddNum(3);
                        Assert.That(sut.FindMedian(), Is.EqualTo(2));
                    },
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}
