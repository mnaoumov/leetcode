using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0981_Time_Based_Key_Value_Store;

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
        public Action<ITimeMap> Test { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        sut.Set("foo", "bar", 1);
                        Assert.That(sut.Get("foo", 1), Is.EqualTo("bar"));
                        Assert.That(sut.Get("foo", 3), Is.EqualTo("bar"));
                        sut.Set("foo", "bar2", 4);
                        Assert.That(sut.Get("foo", 4), Is.EqualTo("bar2"));
                        Assert.That(sut.Get("foo", 5), Is.EqualTo("bar2"));
                    },
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}