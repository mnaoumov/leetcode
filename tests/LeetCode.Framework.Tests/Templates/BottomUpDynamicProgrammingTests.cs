using LeetCode.Templates;

namespace LeetCode.Framework.Tests.Templates;

public class BottomUpDynamicProgrammingTests
{
    [Test]
    public void Get_Fibonacci()
    {
        var dp = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<int, long>(
            Enumerable.Range(0, 21),
            (key, get) => key <= 1 ? key : get(key - 1) + get(key - 2));

        Assert.That(dp.Get(0), Is.EqualTo(0));
        Assert.That(dp.Get(10), Is.EqualTo(55));
        Assert.That(dp.Get(20), Is.EqualTo(6765));
    }

    [Test]
    public void Get_GridPaths_TupleKeys()
    {
        // Paths from (0, 0) to (i, j) moving right or down: C(i + j, i).
        var dp = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<(int i, int j), long>(
            from i in Enumerable.Range(0, 5)
            from j in Enumerable.Range(0, 5)
            select (i, j),
            (key, get) =>
            {
                var (i, j) = key;
                return i == 0 || j == 0 ? 1 : get((i - 1, j)) + get((i, j - 1));
            });

        Assert.That(dp.Get((2, 2)), Is.EqualTo(6));
        Assert.That(dp.Get((4, 4)), Is.EqualTo(70));
    }

    [Test]
    public void Constructor_CalculatesEachStateOnce()
    {
        var callCount = 0;
        var dp = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<int, int>(
            Enumerable.Range(0, 5),
            (key, _) =>
            {
                callCount++;
                return key * 2;
            });

        Assert.That(dp.Get(4), Is.EqualTo(8));
        Assert.That(dp.Get(4), Is.EqualTo(8));
        Assert.That(callCount, Is.EqualTo(5));
    }

    [Test]
    public void LongChain_DoesNotOverflowStack()
    {
        const int n = 200_000;
        var dp = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<int, long>(
            Enumerable.Range(0, n),
            (key, get) => key == 0 ? 0 : get(key - 1) + 1);

        Assert.That(dp.Get(n - 1), Is.EqualTo(n - 1));
    }

    [Test]
    public void WrongOrder_Throws()
    {
        Assert.Throws<InvalidOperationException>(() =>
            _ = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<int, int>(
                [1, 0],
                (key, get) => key == 0 ? 0 : get(key - 1) + 1));
    }

    [Test]
    public void Get_UncalculatedState_Throws()
    {
        var dp = new BottomUpDynamicProgrammingTemplate.BottomUpDynamicProgramming<int, int>(
            Enumerable.Range(0, 3),
            (key, _) => key);

        Assert.Throws<InvalidOperationException>(() => dp.Get(5));
    }
}
