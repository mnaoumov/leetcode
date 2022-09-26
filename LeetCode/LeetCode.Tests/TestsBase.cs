namespace LeetCode.Tests;

public abstract class TestsBase<TSolution>
{
    protected TSolution Solution { get; }

    protected TestsBase(TSolution solution)
    {
        Solution = solution;
    }

    protected static IEnumerable<TSolution> Solutions
    {
        get
        {
            var solutionInterfaceType = typeof(TSolution);
            var solutionTypes = solutionInterfaceType.Assembly.GetTypes().Where(t => t.IsClass && t.IsAssignableTo(solutionInterfaceType));
            var solutions = solutionTypes.Select(t => (TSolution) Activator.CreateInstance(t)!);
            return solutions;
        }
    }
}