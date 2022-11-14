﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Values)!;
        var p = root.FindNode(testCase.P)!;
        var q = root.FindNode(testCase.Q)!;
        var returnNode = root.FindNode(testCase.Output)!;
        Assert.That(solution.LowestCommonAncestor(root, p, q), Is.SameAs(returnNode));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int Q { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 },
                    P = 5,
                    Q = 1,
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 },
                    P = 5,
                    Q = 4,
                    Output = 5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 1, 2 },
                    P = 1,
                    Q = 2,
                    Output = 1,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 1, 2, 3, null, 4 },
                    P = 4,
                    Q = 3,
                    Output = 1,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}