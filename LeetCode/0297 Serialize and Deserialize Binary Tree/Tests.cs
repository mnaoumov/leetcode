using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0297_Serialize_and_Deserialize_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var ser = solution.Create();
        var deser = solution.Create();
        var root = TreeNode.Create(testCase.Values)!;
        var ans = deser.deserialize(ser.serialize(root));
        Assert.That(ans, Is.EqualTo(root));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 1, 2, 3, null, null, 4, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int?>(),
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}