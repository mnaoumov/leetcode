using static LeetCode.Templates.GridTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class GridTests
{
    [Test]
    public void IsInside_ChecksBothBounds()
    {
        Assert.That(new Cell(0, 0).IsInside(2, 3), Is.True);
        Assert.That(new Cell(1, 2).IsInside(2, 3), Is.True);
        Assert.That(new Cell(2, 0).IsInside(2, 3), Is.False);
        Assert.That(new Cell(0, 3).IsInside(2, 3), Is.False);
        Assert.That(new Cell(-1, 0).IsInside(2, 3), Is.False);
        Assert.That(new Cell(0, -1).IsInside(2, 3), Is.False);
    }

    [Test]
    public void Neighbours_Corner_OnlyInsideOnes()
    {
        Assert.That(new Cell(0, 0).Neighbours(3, 3), Is.EquivalentTo(new[] { new Cell(0, 1), new Cell(1, 0) }));
    }

    [Test]
    public void Neighbours_Centre_FourOrEight()
    {
        var centre = new Cell(1, 1);
        Assert.That(centre.Neighbours(3, 3).Count(), Is.EqualTo(4));
        Assert.That(centre.Neighbours(3, 3, includeDiagonals: true).Count(), Is.EqualTo(8));
        Assert.That(centre.Neighbours(3, 3, includeDiagonals: true), Does.Not.Contain(centre));
    }

    [Test]
    public void Directions4_TurningRightIsTheNextIndex()
    {
        var right = Cell.Directions4[0];
        var down = Cell.Directions4[1];
        Assert.That(right, Is.EqualTo((0, 1)));
        Assert.That(down, Is.EqualTo((1, 0)));
    }

    [Test]
    public void Move_WithSteps()
    {
        Assert.That(new Cell(1, 1).Move((1, -1), 3), Is.EqualTo(new Cell(4, -2)));
    }

    [Test]
    public void ManhattanDistance()
    {
        Assert.That(new Cell(1, 5).ManhattanDistance(new Cell(4, 1)), Is.EqualTo(7));
    }

    [Test]
    public void GetValue()
    {
        int[][] jagged = [[1, 2], [3, 4]];
        Assert.That(new Cell(1, 0).GetValue(jagged), Is.EqualTo(3));
        Assert.That(new Cell(0, 1).GetValue(jagged), Is.EqualTo(2));
    }

    [Test]
    public void Cell_IsUsableAsHashKey()
    {
        var visited = new HashSet<Cell> { new(1, 2) };
        Assert.That(visited.Contains(new Cell(1, 2)), Is.True);
    }
}
