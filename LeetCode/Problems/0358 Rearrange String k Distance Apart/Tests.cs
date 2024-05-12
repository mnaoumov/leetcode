using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0358_Rearrange_String_k_Distance_Apart;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var rearrangeString = solution.RearrangeString(testCase.S, testCase.K);

        Assert.That(rearrangeString, Is.EquivalentTo(testCase.Output));

        var letterIndices = new Dictionary<char, int>();

        for (var index = 0; index < rearrangeString.Length; index++)
        {
            var letter = rearrangeString[index];

            if (letterIndices.TryGetValue(letter, out var previousIndex))
            {
                Assert.That(previousIndex, Is.LessThanOrEqualTo(index - testCase.K));
            }

            letterIndices[letter] = index;
        }

    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
