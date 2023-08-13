using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2816_Double_a_Number_Represented_as_a_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DoubleIt(ListNode.Create(testCase.Head)),
            Is.EqualTo(ListNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
