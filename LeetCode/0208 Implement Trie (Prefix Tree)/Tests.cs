using NUnit.Framework;

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public Action<ITrie> Test { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        sut.Insert("apple");
                        Assert.That(sut.Search("apple"), Is.True);
                        Assert.That(sut.Search("app"), Is.False);
                        Assert.That(sut.StartsWith("app"), Is.True);
                        sut.Insert("app");
                        Assert.That(sut.Search("app"), Is.True);
                    },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Test = sut =>
                    {
                        Assert.That(sut.Search("ab"), Is.False);
                        sut.Insert("ab");
                        Assert.That(sut.Search("ab"), Is.True);
                        Assert.That(sut.Search("ab"), Is.True);
                        Assert.That(sut.StartsWith("ab"), Is.True);
                        Assert.That(sut.StartsWith("ab"), Is.True);
                    },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}