namespace LeetCode.Problems._2028_Find_Missing_Observations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var missingRolls = solution.MissingRolls(testCase.Rolls, testCase.Mean, testCase.N);
        if (testCase.Output.Length == 0)
        {
            Assert.That(missingRolls, Has.Length.EqualTo(0));
        }
        else
        {
            Assert.That(missingRolls, Has.Length.EqualTo(testCase.N));
            Assert.That(missingRolls, Has.All.InRange(1, 6));

            var totalSum = testCase.Mean * (testCase.Rolls.Length + testCase.N);
            Assert.That(missingRolls.Sum() + testCase.Rolls.Sum(), Is.EqualTo(totalSum));
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Rolls { get; [UsedImplicitly] init; } = null!;
        public int Mean { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
