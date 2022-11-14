using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0138_Copy_List_with_Random_Pointer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = Node.Create(testCase.HeadValues);
        var copy = solution.CopyRandomList(head);

        var headList = GetNodesList(head);
        var copyList = GetNodesList(copy);

        Assert.That(copyList.Count, Is.EqualTo(headList.Count));

        for (var i = 0; i < copyList.Count; i++)
        {
            var headNode = headList[i];
            var copyNode = copyList[i];
            Assert.That(copyNode, Is.Not.SameAs(headNode));
            Assert.That(copyNode.val, Is.EqualTo(headNode.val));

            if (copyNode.random == null)
            {
                Assert.That(headNode.random, Is.Null);
            }
            else
            {
                Assert.That(headNode.random, Is.Not.Null);
                Assert.That(copyNode.random.val, Is.EqualTo(headNode.random!.val));
            }
        }
    }

    private static List<Node> GetNodesList(Node head)
    {
        var node = head;
        var list = new List<Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.next;
        }

        return list;
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[][] HeadValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    HeadValues = new[]
                    {
                        new int?[] { 7, null }, new int?[] { 13, 0 }, new int?[] { 11, 4 }, new int?[] { 10, 2 }, new int?[] { 1, 0 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    HeadValues = new[]
                    {
                        new int?[] { 1, 1 }, new int?[] { 2, 1 }
                    },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    HeadValues = new[]
                    {
                        new int?[] { 3, null }, new int?[] { 3, 0 }, new int?[] { 3, null }
                    },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}