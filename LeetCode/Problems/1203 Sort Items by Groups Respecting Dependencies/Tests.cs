
using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1203_Sort_Items_by_Groups_Respecting_Dependencies;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = solution.SortItems(testCase.N, testCase.M, testCase.Group, testCase.BeforeItems);

        if (testCase.Output.Length == 0)
        {
            Assert.That(output, Is.Empty);
            return;
        }

        var groups = Enumerable.Range(0, testCase.N).GroupBy(i => testCase.Group[i])
            .ToDictionary(g => g.Key, g => g.ToArray());

        foreach (var (groupId, group) in groups)
        {
            if (groupId == -1)
            {
                continue;
            }

            var indices = group.Select(i => Array.IndexOf(output, i)).OrderBy(j => j).ToArray();

            for (var i = 0; i < indices.Length - 1; i++)
            {
                Assert.That(indices[i + 1], Is.EqualTo(indices[i] + 1));
            }
        }

        for (var i = 0; i < testCase.N; i++)
        {
            foreach (var j in testCase.BeforeItems[i])
            {
                Assert.That(Array.IndexOf(output, j), Is.LessThan(Array.IndexOf(output, i)));
            }
        }
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int[] Group { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> BeforeItems { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
