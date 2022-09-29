using NUnit.Framework;

namespace LeetCode._025_Reverse_Nodes_in_k_Group;

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
            listModificationFunc: list => Solution.ReverseKGroup(list, 2),
            valuesBefore: new[] { 1, 2, 3, 4, 5 },
            valuesAfter: new[] { 2, 1, 4, 3, 5 });
    }

    [Test]
    public void Example2()
    {
        ListNodeTestHelper.TestListNodesByReference(
            listModificationFunc: list => Solution.ReverseKGroup(list, 3),
            valuesBefore: new[] { 1, 2, 3, 4, 5 },
            valuesAfter: new[] { 3, 2, 1, 4, 5 });
    }
}