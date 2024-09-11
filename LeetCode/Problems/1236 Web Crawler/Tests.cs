
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1236_Web_Crawler;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.Crawl(testCase.StartUrl, new HtmlParser(testCase.Urls, testCase.Edges)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string StartUrl { get; [UsedImplicitly] init; } = null!;
        public string[] Urls { get; [UsedImplicitly] init; } = null!;
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
