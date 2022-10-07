﻿using NUnit.Framework;

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
            }
        }
    }
}