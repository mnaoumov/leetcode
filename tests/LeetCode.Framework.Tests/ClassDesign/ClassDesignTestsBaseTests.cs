using LeetCode.ClassDesign;

namespace LeetCode.Framework.Tests.ClassDesign;

public class ClassDesignTestsBaseTests
{
    [Test]
    public void ResolvesOverloadsByArgumentCountAndType()
    {
        Run<Calculators, ICalculator>(
            ["Calculator", "add", "add", "describe", "describe", "count"],
            [[], [1], [1, 2], [5], ["x"], []],
            [null, 1, 3, "int 5", "string x", 3]);
    }

    [Test]
    public void FindsMethodsOfTheInterfacesTheInterfaceExtends()
    {
        Run<Calculators, ICalculator>(["Calculator", "count"], [[], []], [null, 0]);
    }

    [Test]
    public void DoesNotTakeObjectsMethodsForCommands()
    {
        var exception = Assert.Throws<AssertionException>(() =>
            Run<Counters, Counter>(["Counter", "getHashCode"], [[], []], [null, 0]));

        Assert.That(exception.Message, Does.Contain("Unknown command 'getHashCode'"));
    }

    [Test]
    public void RunsAClassSut()
    {
        Run<Counters, Counter>(["Counter", "increment", "increment"], [[], [], []], [null, 1, 2]);
    }

    [Test]
    public void FailsWhenNoOverloadTakesTheArgumentCount()
    {
        var exception = Assert.Throws<AssertionException>(() =>
            Run<Calculators, ICalculator>(["Calculator", "add"], [[], [1, 2, 3]], [null, 6]));

        Assert.That(exception.Message, Does.Contain("No overload of 'add' takes 3 arguments"));
    }

    [TestCase(2, 3, 3)]
    [TestCase(3, 2, 3)]
    [TestCase(3, 3, 2)]
    public void FailsWhenTheArraysDifferInLength(int commandCount, int parameterCount, int outputCount)
    {
        var exception = Assert.Throws<AssertionException>(() =>
            Run<Counters, Counter>(new[] { "Counter", "increment", "increment" }[..commandCount],
                new object[][] { [], [], [] }[..parameterCount], new object?[] { null, 1, 2 }[..outputCount]));

        Assert.That(exception.Message, Does.Contain("one of each per command"));
    }

    [Test]
    public void FailsWhenTheFirstCommandIsNotTheConstructor()
    {
        var exception = Assert.Throws<AssertionException>(() =>
            Run<Counters, Counter>(["increment", "increment"], [[], []], [null, 1]));

        Assert.That(exception.Message, Does.Contain("The first command is 'increment', not the constructor 'Counter'"));
    }

    [Test]
    public void FailsWhenTheConstructorHasAnOutput()
    {
        var exception = Assert.Throws<AssertionException>(() =>
            Run<Counters, Counter>(["Counter", "increment"], [[], []], [true, 1]));

        Assert.That(exception.Message, Does.Contain("The constructor's output is true, not null"));
    }

    [Test]
    public void AcceptsTheConstructorOfAnImplInterface()
    {
        Run<Solutions, ISolutionImpl>(["Solution", "get"], [[], []], [null, 7]);
    }

    [Test]
    public void ComparesNestedFloatingPointCollectionsWithinTolerance()
    {
        Run<Measures, IMeasure>(
            ["Measure", "scalar", "matrix", "list", "ints"],
            [[], [], [], [], []],
            [null, 0.5, new object[] { new object[] { 1, 0.5 }, new object[] { 0.25 } }, new object[] { 1, 0.5 },
                new object[] { 1, 2 }]);
    }

    [Test]
    public void FailsAFloatingPointCollectionOutsideTolerance()
    {
        Assert.Throws<AssertionException>(() =>
            Run<Measures, IMeasure>(["Measure", "matrix"], [[], []],
                [null, new object[] { new object[] { 1, 0.6 }, new object[] { 0.25 } }]));
    }

    private static void Run<TSolution, TSut>(string[] commands, object[][] parameters, object?[] output)
        where TSolution : new()
    {
        var testCase = new ClassDesignTestCase { Commands = commands, Parameters = parameters, Output = output! };
        new Runner<TSolution, TSut>().Run(new TSolution(), testCase);
    }

    // Not public, so NUnit does not take it for a fixture of its own.
    internal sealed class Runner<TSolution, TSut> : ClassDesignTestsBase<TSolution, TSut>
    {
        public void Run(TSolution solution, ClassDesignTestCase testCase) => TestCore(solution, testCase);
    }

    public interface ICountable
    {
        int Count();
    }

    public interface ICalculator : ICountable
    {
        int Add(int a);
        int Add(int a, int b);
        string Describe(string value);
        string Describe(int value);
    }

    public sealed class Calculators
    {
        public ICalculator Create() => new Calculator();

        private sealed class Calculator : ICalculator
        {
            private int _calls;

            public int Count() => _calls;

            public int Add(int a)
            {
                _calls++;
                return a;
            }

            public int Add(int a, int b)
            {
                _calls++;
                return a + b;
            }

            public string Describe(string value)
            {
                _calls++;
                return $"string {value}";
            }

            public string Describe(int value) => $"int {value}";
        }
    }

    public sealed class Counter
    {
        private int _count;

        public int Increment() => ++_count;
    }

    public sealed class Counters
    {
        public Counter Create() => new();
    }

    public interface ISolutionImpl
    {
        int Get();
    }

    public sealed class Solutions
    {
        public ISolutionImpl Create() => new Solution();

        private sealed class Solution : ISolutionImpl
        {
            public int Get() => 7;
        }
    }

    public interface IMeasure
    {
        double Scalar();
        double[][] Matrix();
        IList<double> List();
        double[] Ints();
    }

    public sealed class Measures
    {
        public IMeasure Create() => new Measure();

        private sealed class Measure : IMeasure
        {
            public double Scalar() => 0.5000001;
            public double[][] Matrix() => [[1.0000001, 0.4999999], [0.25]];
            public IList<double> List() => new List<double> { 0.9999999, 0.5000001 };
            public double[] Ints() => [1.0000001, 2];
        }
    }
}
