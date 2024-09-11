using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0791_Custom_Sort_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sorted = solution.CustomSortString(testCase.Order, testCase.S);

        var letterIndexMap = testCase.Order.Select((letter, index) => (letter, index))
            .ToDictionary(x => x.letter, x => x.index);

        for (var i = 0; i < sorted.Length; i++)
        {
            var letter1 = sorted[i];

            if (!letterIndexMap.TryGetValue(letter1, out var value))
            {
                continue;
            }

            for (var j = i + 1; j < sorted.Length; j++)
            {
                var letter2 = sorted[j];

                if (!letterIndexMap.TryGetValue(letter2, out var value1))
                {
                    continue;
                }

                Assert.That(value, Is.LessThanOrEqualTo(value1));
            }
        }
    }

    public class TestCase : TestCaseBase
    {
        public string Order { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
    }
}
