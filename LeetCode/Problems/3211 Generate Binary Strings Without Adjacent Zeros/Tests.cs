using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3211_Generate_Binary_Strings_Without_Adjacent_Zeros;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ValidStrings(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
