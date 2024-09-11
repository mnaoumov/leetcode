using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0271_Encode_and_Decode_Strings
{
    [UsedImplicitly]
    public class Tests : TestsBase<ISolution, Tests.TestCase>
    {
        protected override void TestImpl(ISolution solution, TestCase testCase)
        {
            var codec = solution.Create();
            AssertCollectionEqualWithDetails(codec.decode(codec.encode(testCase.Input)), testCase.Input);
        }

        public class TestCase : TestCaseBase
        {
            public string[] Input { get; [UsedImplicitly] init; } = null!;
        }
    }
}
