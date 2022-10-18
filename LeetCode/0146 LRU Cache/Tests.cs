using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create(testCase.Capacity);
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Capacity { get; private init; }
        public Action<ILRUCache> Test { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Capacity = 2,
                    Test = sut =>
                    {
                        sut.Put(1, 1);
                        sut.Put(2, 2);
                        Assert.That(sut.Get(1), Is.EqualTo(1));
                        sut.Put(3, 3);
                        Assert.That(sut.Get(2), Is.EqualTo(-1));
                        sut.Put(4, 4);
                        Assert.That(sut.Get(1), Is.EqualTo(-1));
                        Assert.That(sut.Get(3), Is.EqualTo(3));
                        Assert.That(sut.Get(4), Is.EqualTo(4));
                    },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Capacity = 2,
                    Test = sut =>
                    {
                        sut.Put(2, 1);
                        sut.Put(2, 2);
                        Assert.That(sut.Get(2), Is.EqualTo(2));
                        sut.Put(1, 1);
                        sut.Put(4, 1);
                        Assert.That(sut.Get(2), Is.EqualTo(-1));
                    },
                    TestCaseName = nameof(Solution01)
                };
            }
        }
    }
}