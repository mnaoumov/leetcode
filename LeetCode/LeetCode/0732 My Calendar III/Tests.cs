using LeetCode._0002_Add_Two_Numbers;
using NUnit.Framework;

namespace LeetCode._0732_My_Calendar_III;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public Action<IMyCalendarThree> Test { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        Assert.That(sut.Book(10, 20), Is.EqualTo(1));
                        Assert.That(sut.Book(50, 60), Is.EqualTo(1));
                        Assert.That(sut.Book(10, 40), Is.EqualTo(2));
                        Assert.That(sut.Book(5, 15), Is.EqualTo(3));
                        Assert.That(sut.Book(5, 10), Is.EqualTo(3));
                        Assert.That(sut.Book(25, 55), Is.EqualTo(3));
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Test = sut =>
                    {
                        Assert.That(sut.Book(26, 35), Is.EqualTo(1));
                        Assert.That(sut.Book(26, 32), Is.EqualTo(2));
                        Assert.That(sut.Book(25, 32), Is.EqualTo(3));
                        Assert.That(sut.Book(18, 26), Is.EqualTo(3));
                        Assert.That(sut.Book(40, 45), Is.EqualTo(3));
                        Assert.That(sut.Book(19, 26), Is.EqualTo(3));
                        Assert.That(sut.Book(48, 50), Is.EqualTo(3));
                        Assert.That(sut.Book(1, 6), Is.EqualTo(3));
                        Assert.That(sut.Book(46, 50), Is.EqualTo(3));
                        Assert.That(sut.Book(11, 18), Is.EqualTo(3));
                    },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}