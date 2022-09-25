﻿using LeetCode.<<<Namespace>>>;
using NUnit.Framework;

namespace LeetCode.Tests.<<<Namespace>>>;

[TestFixtureSource(nameof(Solutions))]
public class Tests
{
    private readonly ISolution _solution;

    public Tests(ISolution solution)
    {
        _solution = solution;
    }

    [Test]
    public void Example1()
    {
        Assert.That(_solution, Is.Not.Null);
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }
}