using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0027_Remove_Element;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        var k = solution.RemoveElement(nums, testCase.Val);

        Assert.That(k, Is.EqualTo(testCase.ExpectedNums.Length));
        Assert.That(nums.Take(k).OrderBy(x => x), Is.EqualTo(testCase.ExpectedNums));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Val { get; [UsedImplicitly] init; }
        public int[] ExpectedNums { get; [UsedImplicitly] init; } = null!;
    }
}