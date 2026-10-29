namespace LeetCode.Problems._3259_Maximum_Energy_Boost_From_Two_Drinks;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxEnergyBoost(testCase.EnergyDrinkA, testCase.EnergyDrinkB), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] EnergyDrinkA { get; [UsedImplicitly] init; } = null!;
        public int[] EnergyDrinkB { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
