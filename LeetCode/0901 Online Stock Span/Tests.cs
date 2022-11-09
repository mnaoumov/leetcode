using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0901_Online_Stock_Span;

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
        public Action<IStockSpanner> Test { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        Assert.That(sut.Next(100), Is.EqualTo(1));
                        Assert.That(sut.Next(80), Is.EqualTo(1));
                        Assert.That(sut.Next(60), Is.EqualTo(1));
                        Assert.That(sut.Next(70), Is.EqualTo(2));
                        Assert.That(sut.Next(60), Is.EqualTo(1));
                        Assert.That(sut.Next(75), Is.EqualTo(4));
                        Assert.That(sut.Next(85), Is.EqualTo(6));
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Test = sut =>
                    {
                        Assert.That(sut.Next(29), Is.EqualTo(1));
                        Assert.That(sut.Next(91), Is.EqualTo(2));
                        Assert.That(sut.Next(62), Is.EqualTo(1));
                        Assert.That(sut.Next(76), Is.EqualTo(2));
                        Assert.That(sut.Next(51), Is.EqualTo(1));
                    },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
