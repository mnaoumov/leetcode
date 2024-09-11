using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0157_Read_N_Characters_Given_Read4;

[UsedImplicitly]
public class Tests : TestsBase<Reader4, Tests.TestCase>
{
    protected override void TestImpl(Reader4 solution, TestCase testCase)
    {
        solution.SetFile(testCase.File);
        var buf = new char[testCase.N];
        Assert.That(solution.Read(buf, testCase.N), Is.EqualTo(testCase.Output));
        AssertCollectionEqualWithDetails(buf.Take(testCase.Output), testCase.File.ToCharArray());
    }

    public class TestCase : TestCaseBase
    {
        public string File { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
