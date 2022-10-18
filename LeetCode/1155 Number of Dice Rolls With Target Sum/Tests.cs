using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1155_Number_of_Dice_Rolls_With_Target_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumRollsToTarget(testCase.N, testCase.K, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int K { get; private init; }
        public int Target { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 1,
                    K = 6,
                    Target = 3,
                    Output = 1,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    N = 2,
                    K = 6,
                    Target = 7,
                    Output = 6,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    N = 30,
                    K = 30,
                    Target = 500,
                    Output = 222616187,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}