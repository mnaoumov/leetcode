using JetBrains.Annotations;

namespace LeetCode.Problems._0158_Read_N_Characters_Given_read4_II___Call_Multiple_Times;

[UsedImplicitly]
public class Tests : TestsBase<Reader4, Tests.TestCase>
{
    protected override void TestImpl(Reader4 solution, TestCase testCase)
    {
        solution.SetFile(testCase.File);
        var buf = new char[testCase.File.Length];
        var output = testCase.Queries.Select(query => solution.Read(buf, query)).ToArray();
        AssertCollectionEqualWithDetails(output, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string File { get; [UsedImplicitly] init; } = null!;
        public int[] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
