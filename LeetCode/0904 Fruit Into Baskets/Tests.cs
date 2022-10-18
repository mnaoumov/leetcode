using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0904_Fruit_Into_Baskets;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TotalFruit(testCase.Fruits), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Fruits { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Fruits = new[] { 1, 2, 1 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Fruits = new[] { 0, 1, 2, 2 },
                    Output = 3,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Fruits = new[] { 1, 2, 3, 2, 2 },
                    Output = 4,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Fruits = Enumerable.Repeat(0, 32768).ToArray(),
                    Output = 32768,
                    TestCaseName = nameof(Solution1)
                };
 
            }
        }
    }
}