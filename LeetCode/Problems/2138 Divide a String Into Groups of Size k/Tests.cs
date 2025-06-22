namespace LeetCode.Problems._2138_Divide_a_String_Into_Groups_of_Size_k;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.DivideString(testCase.S, testCase.K, testCase.Fill), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public char Fill { get; [UsedImplicitly] init; }
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
