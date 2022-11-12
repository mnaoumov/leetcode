using JetBrains.Annotations;

namespace LeetCode._2468_Split_Message_Based_on_Limit;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SplitMessage(testCase.Message, testCase.Limit), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Message { get; private init; } = null!;
        public int Limit { get; private init; }
        public string[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Message = "this is really a very awesome message",
                    Limit = 9,
                    Output = new[]
                    {
                        "thi<1/14>", "s i<2/14>", "s r<3/14>", "eal<4/14>", "ly <5/14>", "a v<6/14>", "ery<7/14>", " aw<8/14>", "eso<9/14>", "me<10/14>",
    " m<11/14>", "es<12/14>", "sa<13/14>", "ge<14/14>"
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Message = "short message",
                    Limit = 15,
                    Output = new[] { "short mess<1/2>", "age<2/2>" },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
