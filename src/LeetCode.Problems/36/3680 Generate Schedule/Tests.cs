namespace LeetCode.Problems._3680_Generate_Schedule;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var schedule = solution.GenerateSchedule(testCase.N);

        if (testCase.Output.Length == 0)
        {
            Assert.That(schedule.Length, Is.EqualTo(0));
            return;
        }

        Assert.That(schedule.Length, Is.EqualTo(testCase.N * (testCase.N - 1)));

        for (var i = 0; i < schedule.Length; i++)
        {
            var (home, away) = (schedule[i][0], schedule[i][1]);
            Assert.That(home, Is.InRange(0, testCase.N - 1), $"Game {i}: home team {home} is out of range");
            Assert.That(away, Is.InRange(0, testCase.N - 1), $"Game {i}: away team {away} is out of range");
            Assert.That(home, Is.Not.EqualTo(away), $"Game {i}: home team {home} is the same as away team {away}");

            if (i == 0)
            {
                continue;
            }

            var (previousHome, previousAway) = (schedule[i - 1][0], schedule[i - 1][1]);
            Assert.That(home, Is.Not.EqualTo(previousHome));
            Assert.That(home, Is.Not.EqualTo(previousAway));
            Assert.That(away, Is.Not.EqualTo(previousHome));
            Assert.That(away, Is.Not.EqualTo(previousAway));
        }
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
