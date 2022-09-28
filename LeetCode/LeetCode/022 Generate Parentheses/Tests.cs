using NUnit.Framework;
namespace LeetCode._022_Generate_Parentheses;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.GenerateParenthesis(3),
            Is.EquivalentTo(new[] { "((()))", "(()())", "(())()", "()(())", "()()()" }));
    }
    
    [Test]
    public void Example2()
    {
        Assert.That(Solution.GenerateParenthesis(1),
            Is.EquivalentTo(new[] { "()" }));
    }
}