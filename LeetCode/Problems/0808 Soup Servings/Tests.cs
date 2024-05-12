using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0808_Soup_Servings;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SoupServings(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
