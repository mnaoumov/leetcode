using NUnit.Framework;

namespace LeetCode._0055_Jump_Game;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanJump(testCase.Nums), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new []{ 2, 3, 1, 1, 4 },
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new []{ 3, 2, 1, 0, 4 },
                    Return = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}