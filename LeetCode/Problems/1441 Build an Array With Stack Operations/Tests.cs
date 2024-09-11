namespace LeetCode.Problems._1441_Build_an_Array_With_Stack_Operations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ans = solution.BuildArray(testCase.Target, testCase.N);

        Assert.That(ans, Has.Count.EqualTo(testCase.Output.Count));

        var stack = new Stack<int>();

        var num = 1;

        foreach (var action in ans)
        {
            switch (action)
            {
                case "Push":
                    stack.Push(num);
                    num++;
                    break;
                case "Pop":
                    stack.Pop();
                    break;
            }
        }

        AssertCollectionEqualWithDetails(stack.Reverse(), testCase.Target);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Target { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
