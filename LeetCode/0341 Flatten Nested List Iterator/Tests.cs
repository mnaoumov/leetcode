using JetBrains.Annotations;

namespace LeetCode._0341_Flatten_Nested_List_Iterator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var i = solution.Create(testCase.NestedList);

        var list = new List<int>();

        while (i.HasNext())
        {
            list.Add(i.Next());
        }

        AssertCollectionEqualWithDetails(list, testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public NestedInteger[] NestedList { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    NestedList = new NestedInteger[]
                    {
                        new NestedIntegerImpl(new NestedInteger[]
                        {
                            new NestedIntegerImpl(1),
                            new NestedIntegerImpl(1)
                        }),
                        new NestedIntegerImpl(2),
                        new NestedIntegerImpl(new NestedInteger[]
                        {
                            new NestedIntegerImpl(1),
                            new NestedIntegerImpl(1)
                        })
                    },
                    Output = new[] { 1, 1, 2, 1, 1 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    NestedList = new NestedInteger[]
                    {
                        new NestedIntegerImpl(1),
                        new NestedIntegerImpl(new NestedInteger[]
                        {
                            new NestedIntegerImpl(4),
                            new NestedIntegerImpl(new NestedInteger[]
                            {
                                new NestedIntegerImpl(6)
                            })
                        })
                    },
                    Output = new[] { 1, 4, 6 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    NestedList = new NestedInteger[]
                    {
                        new NestedIntegerImpl(Array.Empty<NestedInteger>())
                    },
                    Output = Array.Empty<int>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}