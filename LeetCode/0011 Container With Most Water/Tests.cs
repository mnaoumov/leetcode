using NUnit.Framework;

namespace LeetCode._0011_Container_With_Most_Water;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxArea(testCase.Height), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Height { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Height = new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 },
                    Output = 49,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Height = new[] { 1, 1 },
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
