using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LeetCode;

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

    protected static CollectionItemsEqualConstraint IsEquivalentToIgnoringItemOrder<T>(IEnumerable<IEnumerable<T>> expected)
    {
        return Is.EquivalentTo(expected)
            .Using<IEnumerable<T>>((a, b) =>
            {
                var aSorted = a.OrderBy<T, T>(x => x);
                var bSorted = b.OrderBy<T, T>(x => x);
                return aSorted.SequenceEqual(bSorted);
            });
    }
}