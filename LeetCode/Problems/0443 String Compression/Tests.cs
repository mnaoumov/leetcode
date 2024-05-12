using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0443_String_Compression;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var chars = testCase.Chars.ToArray();
        Assert.That(solution.Compress(chars), Is.EqualTo(testCase.Output.Length));
        AssertCollectionEqualWithDetails(chars.Take(testCase.Output.Length), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public char[] Chars { get; [UsedImplicitly] init; } = null!;
        public char[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
