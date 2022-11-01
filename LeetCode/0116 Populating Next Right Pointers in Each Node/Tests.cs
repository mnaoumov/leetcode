using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0116_Populating_Next_Right_Pointers_in_Each_Node;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = solution.Connect(Node.Create(testCase.RootValues));

        var node = output;
        var parent = new Node { left = output };
        var previous = new Node { next = output };

        foreach (var value in testCase.OutputValues)
        {
            if (value == null)
            {
                Assert.That(previous, Is.Not.Null);
                Assert.That(previous!.next, Is.Null);
                node = parent.left!.left!;
                parent = parent.left;
                previous = null;
            }
            else
            {
                Assert.That(node, Is.Not.Null);
                Assert.That(node!.val, Is.EqualTo(value));

                if (previous != null)
                {
                    Assert.That(previous.next, Is.EqualTo(node));
                }

                (node, previous) = (node.next, node);
            }
        }
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] RootValues { get; private init; } = null!;
        public int?[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new[] { 1, 2, 3, 4, 5, 6, 7 },
                    OutputValues = new int?[] { 1, null, 2, 3, null, 4, 5, 6, 7, null },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = Array.Empty<int>(),
                    OutputValues = Array.Empty<int?>(),
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
