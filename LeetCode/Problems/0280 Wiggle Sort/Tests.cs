using Newtonsoft.Json;
using NUnit.Framework.Constraints;

namespace LeetCode.Problems._0280_Wiggle_Sort;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        solution.WiggleSort(nums);

        for (var i = 0; i < nums.Length - 1; i++)
        {
            IResolveConstraint constraint =
                i % 2 == 0 ? Is.LessThanOrEqualTo(nums[i + 1]) : Is.GreaterThanOrEqualTo(nums[i + 1]);
            Assert.That(nums[i], constraint, $"{JsonConvert.SerializeObject(nums)} is not wiggle at index {i}");
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
    }
}
