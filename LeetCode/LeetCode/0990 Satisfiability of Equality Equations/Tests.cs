using NUnit.Framework;

namespace LeetCode._0990_Satisfiability_of_Equality_Equations;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EquationsPossible(testCase.Equations), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Equations { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Equations = new[] { "a==b", "b!=a" },
                    Return = false,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Equations = new[] { "b==a", "a==b" },
                    Return = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Equations = new[] { "e==d", "e==a", "f!=d", "b!=c", "a==b" },
                    Return = true,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
