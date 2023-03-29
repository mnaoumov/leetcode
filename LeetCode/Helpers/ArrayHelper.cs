namespace LeetCode;

public static class ArrayHelper
{
    public static T[,] ArrayOfArraysTo2D<T>(T[][] arrayOfArrays)
    {
        var n = arrayOfArrays.Length;
        var m = arrayOfArrays[0].Length;
        var array2D = new T[n, m];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                array2D[i, j] = arrayOfArrays[i][j];
            }
        }

        return array2D;
    }

    public static void Copy2DToArrayOfArrays<T>(T[,] array2D, T[][] arrayOfArrays)
    {
        var n = array2D.GetLength(0);
        var m = array2D.GetLength(1);

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                arrayOfArrays[i][j] = array2D[i, j];
            }
        }
    }

    public static T[][] DeepCopy<T>(IEnumerable<T[]> arrayOfArrays) => arrayOfArrays.Select(array => array.ToArray()).ToArray();
}