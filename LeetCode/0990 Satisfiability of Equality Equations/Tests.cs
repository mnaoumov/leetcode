using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0990_Satisfiability_of_Equality_Equations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EquationsPossible(testCase.Equations), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Equations { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Equations = new[] { "a==b", "b!=a" },
                    Output = false,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Equations = new[] { "b==a", "a==b" },
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Equations = new[] { "e==d", "e==a", "f!=d", "b!=c", "a==b" },
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
