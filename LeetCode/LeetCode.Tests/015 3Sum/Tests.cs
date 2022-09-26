using LeetCode._015_3Sum;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeetCode.Tests._015_3Sum;

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
        Assert.That(_solution.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 }),
            IsEquivalentToIgnoringItemOrder(new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } }));
    }

    [Test]
    public void Example2()
    {
        Assert.That(_solution.ThreeSum(new[] { 0, 1, 1 }), IsEquivalentToIgnoringItemOrder(Array.Empty<int[]>()));
    }

    [Test]
    public void Example3()
    {
        Assert.That(_solution.ThreeSum(new[] { 0, 0, 0 }), IsEquivalentToIgnoringItemOrder(new[] { new[] { 0, 0, 0 } }));
    }

    private static IEnumerable<ISolution> Solutions
    {
        get
        {
            yield return new Solution();
        }
    }

    private static CollectionItemsEqualConstraint IsEquivalentToIgnoringItemOrder(int[][] expected)
    {
        return Is.EquivalentTo(expected)
            .Using<int[]>((a, b) =>
            {
                var aSorted = a.OrderBy(x => x);
                var bSorted = b.OrderBy(x => x);
                return aSorted.SequenceEqual(bSorted);
            });
    }
}