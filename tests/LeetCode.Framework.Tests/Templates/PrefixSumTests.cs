using static LeetCode.Templates.PrefixSumTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class PrefixSumTests
{
    [Test]
    public void Sum_HalfOpenRanges()
    {
        var prefixSum = new PrefixSum([1, 2, 3, 4, 5]);
        Assert.That(prefixSum.Sum(0, 5), Is.EqualTo(15));
        Assert.That(prefixSum.Sum(1, 3), Is.EqualTo(5));
        Assert.That(prefixSum.Sum(2, 2), Is.EqualTo(0));
        Assert.That(prefixSum.Total, Is.EqualTo(15));
    }

    [Test]
    public void Sum_LargeValues_DoNotOverflow()
    {
        var prefixSum = new PrefixSum([int.MaxValue, int.MaxValue]);
        Assert.That(prefixSum.Total, Is.EqualTo(2L * int.MaxValue));
    }

    [Test]
    public void Sum_Empty()
    {
        Assert.That(new PrefixSum([]).Total, Is.EqualTo(0));
    }

    [Test]
    public void RectangleSum_MatchesBruteForce()
    {
        var random = new Random(1);
        var matrix = Enumerable.Range(0, 5).Select(_ => Enumerable.Range(0, 4).Select(_ => random.Next(-10, 10)).ToArray()).ToArray();
        var prefixSum = new PrefixSum2D(matrix);

        for (var row1 = 0; row1 <= 5; row1++)
        {
            for (var row2 = row1; row2 <= 5; row2++)
            {
                for (var column1 = 0; column1 <= 4; column1++)
                {
                    for (var column2 = column1; column2 <= 4; column2++)
                    {
                        long expected = 0;

                        for (var row = row1; row < row2; row++)
                        {
                            for (var column = column1; column < column2; column++)
                            {
                                expected += matrix[row][column];
                            }
                        }

                        Assert.That(prefixSum.RectangleSum(row1, column1, row2, column2), Is.EqualTo(expected));
                    }
                }
            }
        }
    }
}
