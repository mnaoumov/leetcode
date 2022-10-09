﻿using NUnit.Framework;

namespace LeetCode._0114_Flatten_Binary_Tree_to_Linked_List;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Values)!;
        solution.Flatten(root);
        Assert.That(root, Is.EqualTo(TreeNode.Create(testCase.ReturnValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public int?[] ReturnValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 1, 2, 5, 3, 4, null, 6 },
                    ReturnValues = new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int?>(),
                    ReturnValues = Array.Empty<int?>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 0 },
                    ReturnValues = new int?[] { 0 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}