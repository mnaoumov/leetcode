namespace LeetCode.Problems._0089_Gray_Code;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var output = solution.GrayCode(testCase.N);

        Assert.That(output, Has.Count.EqualTo(Math.Pow(2, testCase.N)));
        Assert.That(output, Has.All.InRange(0, Math.Pow(2, testCase.N) - 1));
        Assert.That(output[0], Is.EqualTo(0));
        Assert.That(output, Is.Unique);

        for (var i = 0; i < output.Count - 1; i++)
        {
            AssertDifferByExactlyOneBit(output[i], output[i + 1]);
        }

        AssertDifferByExactlyOneBit(output[0], output[^1]);
    }

    private static void AssertDifferByExactlyOneBit(int num1, int num2)
    {
        var count1 = CountOneBit(num1);
        var count2 = CountOneBit(num2);

        Assert.That(count1 - count2, Is.EqualTo(1).Or.EqualTo(-1),
            $"{Convert.ToString(num1, 2)} and {Convert.ToString(num2, 2)} don't differ at exactly one bit");
    }

    private static int CountOneBit(int num)
    {
        var result = 0;
        while (num > 0)
        {
            if (num % 2 == 1)
            {
                result++;
            }

            num /= 2;
        }

        return result;
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
    }
}
