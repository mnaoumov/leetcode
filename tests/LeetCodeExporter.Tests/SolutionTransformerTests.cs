using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

public class SolutionTransformerTests
{
    [Test]
    public void Transform_MethodProblem_RemovesNamespaceAndAttributes()
    {
        var input = """
            namespace LeetCode.Problems._0001_Two_Sum;

            /// <summary>
            /// https://leetcode.com/problems/two-sum/
            /// </summary>
            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public int[] TwoSum(int[] nums, int target)
                {
                    return Array.Empty<int>();
                }
            }
            """;

        var expected =
            """
            public class Solution
            {
                public int[] TwoSum(int[] nums, int target)
                {
                    return Array.Empty<int>();
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_MethodProblem_PreservesUsings()
    {
        var input = """
            using System.Text;

            namespace LeetCode.Problems._0006_Zigzag_Conversion;

            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public string Convert(string s, int numRows)
                {
                    var sb = new StringBuilder();
                    return sb.ToString();
                }
            }
            """;

        var expected =
            """
            using System.Text;

            public class Solution
            {
                public string Convert(string s, int numRows)
                {
                    var sb = new StringBuilder();
                    return sb.ToString();
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_MethodProblem_FiltersNonSystemUsings()
    {
        var input = """
            using System.Text;
            using LeetCode.Helpers;

            namespace LeetCode.Problems._0001;

            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public int Solve() { return 0; }
            }
            """;

        var expected =
            """
            using System.Text;

            public class Solution
            {
                public int Solve()
                {
                    return 0;
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_MethodProblem_PreservesInnerHelperClasses()
    {
        var input = """
            namespace LeetCode.Problems._3129;

            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public int Solve()
                {
                    var dp = new Helper();
                    return dp.Value;
                }

                private class Helper
                {
                    public int Value => 42;
                }
            }
            """;

        var expected =
            """
            public class Solution
            {
                public int Solve()
                {
                    var dp = new Helper();
                    return dp.Value;
                }

                private class Helper
                {
                    public int Value => 42;
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_MethodProblem_RemovesSkipSolutionAttribute()
    {
        var input = """
            namespace LeetCode.Problems._0001;

            [UsedImplicitly]
            [SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
            public class Solution1 : ISolution
            {
                public int Solve() { return 0; }
            }
            """;

        var expected =
            """
            public class Solution
            {
                public int Solve()
                {
                    return 0;
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_ClassDesign_UnwrapsInnerClass()
    {
        var input = """
            namespace LeetCode.Problems._3508_Implement_Router;

            /// <summary>
            /// https://leetcode.com/problems/implement-router/
            /// </summary>
            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public IRouter Create(int memoryLimit) => new Router(memoryLimit);

                private class Router : IRouter
                {
                    private readonly int _memoryLimit;

                    public Router(int memoryLimit) => _memoryLimit = memoryLimit;

                    public bool AddPacket(int source, int destination, int timestamp)
                    {
                        return true;
                    }
                }
            }
            """;

        var expected =
            """
            public class Router
            {
                private readonly int _memoryLimit;
                public Router(int memoryLimit) => _memoryLimit = memoryLimit;
                public bool AddPacket(int source, int destination, int timestamp)
                {
                    return true;
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_ClassDesign_RemovesInterfaceButKeepsBaseClass()
    {
        var input = """
            namespace LeetCode.Problems._0001;

            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public IMyClass Create() => new MyClass();

                private sealed class MyClass : SomeBaseClass, IMyClass
                {
                    public void DoStuff() { }
                }
            }
            """;

        var expected =
            """
            public class MyClass : SomeBaseClass
            {
                public void DoStuff()
                {
                }
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }

    [Test]
    public void Transform_ClassDesign_PreservesUsings()
    {
        var input = """
            using System.Text;

            namespace LeetCode.Problems._0001;

            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public IWidget Create() => new Widget();

                private class Widget : IWidget
                {
                    public string Name => new StringBuilder().ToString();
                }
            }
            """;

        var expected =
            """
            using System.Text;

            public class Widget
            {
                public string Name => new StringBuilder().ToString();
            }

            """;

        Assert.That(SolutionTransformer.Transform(input), Is.EqualTo(expected));
    }
}
