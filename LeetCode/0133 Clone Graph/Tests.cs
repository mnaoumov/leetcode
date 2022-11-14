using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0133_Clone_Graph;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var node = Node.Create(testCase.AdjustmentLists);
        var clone = solution.CloneGraph(node);
        var checkedValues = new HashSet<int>();
        AssertIsClone(node, clone);

        void AssertIsClone(Node? node1, Node? node2)
        {
            if (node1 == null)
            {
                Assert.That(node2, Is.Null);
            }
            else
            {
                if (!checkedValues.Add(node!.val))
                {
                    return;
                }

                Assert.That(node2, Is.Not.Null);
                Assert.That(node1, Is.Not.SameAs(node2));
                Assert.That(node1.val, Is.EqualTo(node2!.val));
                Assert.That(node1.neighbors.Count, Is.EqualTo(node2.neighbors.Count));
                for (var i = 0; i < node1.neighbors.Count; i++)
                {
                    AssertIsClone(node1.neighbors[i], node2.neighbors[i]);
                }
            }

        }

    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] AdjustmentLists { get; [UsedImplicitly] init; } = null!;
    }
}