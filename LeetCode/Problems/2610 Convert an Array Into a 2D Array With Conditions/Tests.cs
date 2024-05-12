using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2610_Convert_an_Array_Into_a_2D_Array_With_Conditions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var list = solution.FindMatrix(testCase.Nums);

        foreach (var arr in list)
        {
            Assert.That(arr, Is.Unique);
        }

        Assert.That(list.SelectMany(x => x), Is.EquivalentTo(testCase.Nums));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
    }
}
