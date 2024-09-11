using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0412_Fizz_Buzz;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FizzBuzz(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
