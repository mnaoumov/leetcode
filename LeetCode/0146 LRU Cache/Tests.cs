using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, SutTestCase>
{
    protected override void TestImpl(ISolution solution, SutTestCase testCase)
    {
        TestSut<ILRUCache>(solution, testCase);
    }
}