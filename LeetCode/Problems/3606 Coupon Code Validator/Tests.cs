namespace LeetCode.Problems._3606_Coupon_Code_Validator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ValidateCoupons(testCase.Code, testCase.BusinessLine, testCase.IsActive), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Code { get; [UsedImplicitly] init; } = null!;
        public string[] BusinessLine { get; [UsedImplicitly] init; } = null!;
        public bool[] IsActive { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
