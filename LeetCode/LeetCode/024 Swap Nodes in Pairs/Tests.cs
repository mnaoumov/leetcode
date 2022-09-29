using NUnit.Framework;

namespace LeetCode._024_Swap_Nodes_in_Pairs;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: Solution.SwapPairs,
            valuesBefore: new[] { 1, 2, 3, 4 },
            valuesAfter: new[] { 2, 1, 4, 3 });
    }

    [Test]
    public void Example2()
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: Solution.SwapPairs,
            valuesBefore: Array.Empty<int>(),
            valuesAfter: Array.Empty<int>());
    }

    [Test]
    public void Example3()
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: Solution.SwapPairs,
            valuesBefore: new[] { 1 },
            valuesAfter: new[] { 1 });
    }
}