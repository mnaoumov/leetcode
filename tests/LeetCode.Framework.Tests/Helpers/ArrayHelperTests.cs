using LeetCode.Helpers;

namespace LeetCode.Tests.Helpers;

public class ArrayHelperTests
{
    [Test]
    public void ArrayOfArraysTo2D_ConvertsCorrectly()
    {
        int[][] jagged = [[1, 2, 3], [4, 5, 6]];
        var result = ArrayHelper.ArrayOfArraysTo2D(jagged);

        Assert.That(result.GetLength(0), Is.EqualTo(2));
        Assert.That(result.GetLength(1), Is.EqualTo(3));
        Assert.That(result[0, 0], Is.EqualTo(1));
        Assert.That(result[1, 2], Is.EqualTo(6));
    }

    [Test]
    public void Copy2DToArrayOfArrays_CopiesCorrectly()
    {
        var array2D = new int[2, 3];
        array2D[0, 0] = 1;
        array2D[0, 1] = 2;
        array2D[1, 0] = 3;
        array2D[1, 2] = 4;

        int[][] target = [new int[3], new int[3]];
        ArrayHelper.Copy2DToArrayOfArrays(array2D, target);

        Assert.That(target[0][0], Is.EqualTo(1));
        Assert.That(target[0][1], Is.EqualTo(2));
        Assert.That(target[1][0], Is.EqualTo(3));
        Assert.That(target[1][2], Is.EqualTo(4));
    }

    [Test]
    public void DeepCopy_CreatesIndependentCopy()
    {
        int[][] original = [[1, 2], [3, 4]];
        var copy = ArrayHelper.DeepCopy(original);

        Assert.That(copy, Is.EqualTo(original));
        copy[0][0] = 99;
        Assert.That(original[0][0], Is.EqualTo(1));
    }
}
