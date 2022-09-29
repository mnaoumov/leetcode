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
        TestSwapPairs(valuesBeforeSwapping: new[] { 1, 2, 3, 4 }, valuesAfterSwapping: new[] { 2, 1, 4, 3 });
    }

    [Test]
    public void Example2()
    {
        TestSwapPairs(valuesBeforeSwapping: Array.Empty<int>(), valuesAfterSwapping: Array.Empty<int>());
    }

    [Test]
    public void Example3()
    {
        TestSwapPairs(valuesBeforeSwapping: new[] { 1 }, valuesAfterSwapping: new[] { 1 });
    }

    private void TestSwapPairs(int[] valuesBeforeSwapping, int[] valuesAfterSwapping)
    {
        var listBeforeSwapping = valuesBeforeSwapping.Any() ? ListNode.Create(valuesBeforeSwapping) : null;

        var valueToNodeMap = new Dictionary<int, ListNode>();

        var node = listBeforeSwapping;

        while (node != null)
        {
            valueToNodeMap.Add(node.val, node);
            node = node.next;
        }

        var listAfterSwapping = Solution.SwapPairs(listBeforeSwapping);

        node = listAfterSwapping;

        foreach (var valueAfterSwapping in valuesAfterSwapping)
        {
            Assert.That(node, Is.SameAs(valueToNodeMap[valueAfterSwapping]));
            node = node!.next;
        }

        Assert.That(node, Is.Null);
    }
}