using NUnit.Framework;

namespace LeetCode._017_Letter_Combinations_of_a_Phone_Number;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        Assert.That(Solution.LetterCombinations("23"), Is.EquivalentTo(new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }));
    }

    [Test]
    public void Example2()
    {
        Assert.That(Solution.LetterCombinations(""), Is.EquivalentTo(Array.Empty<string>()));
    }

    [Test]
    public void Example3()
    {
        Assert.That(Solution.LetterCombinations("2"), Is.EquivalentTo(new[] { "a", "b", "c" }));
    }
}