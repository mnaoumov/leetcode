using static LeetCode.Templates.TrieTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class TrieTests
{
    [Test]
    public void Contains_OnlyWholeWords()
    {
        var trie = new Trie();
        trie.Insert("apple");
        Assert.That(trie.Contains("apple"), Is.True);
        Assert.That(trie.Contains("app"), Is.False);
        Assert.That(trie.StartsWith("app"), Is.True);
        Assert.That(trie.StartsWith("b"), Is.False);
    }

    [Test]
    public void EmptyPrefix_CountsEveryWord()
    {
        var trie = new Trie();
        Assert.That(trie.StartsWith(""), Is.False);
        trie.Insert("a");
        trie.Insert("b");
        Assert.That(trie.CountPrefix(""), Is.EqualTo(2));
    }

    [Test]
    public void Counts_WithDuplicates()
    {
        var trie = new Trie();
        trie.Insert("app");
        trie.Insert("app");
        trie.Insert("apple");
        Assert.That(trie.CountWord("app"), Is.EqualTo(2));
        Assert.That(trie.CountPrefix("app"), Is.EqualTo(3));
        Assert.That(trie.CountPrefix("appl"), Is.EqualTo(1));
    }

    [Test]
    public void Remove_RemovesOneCopyAndPrunes()
    {
        var trie = new Trie();
        trie.Insert("app");
        trie.Insert("apple");
        Assert.That(trie.Remove("apple"), Is.True);
        Assert.That(trie.Contains("apple"), Is.False);
        Assert.That(trie.StartsWith("appl"), Is.False);
        Assert.That(trie.Find("app")!.Children, Is.Empty);
        Assert.That(trie.Contains("app"), Is.True);
    }

    [Test]
    public void Remove_Missing_ReturnsFalseAndChangesNothing()
    {
        var trie = new Trie();
        trie.Insert("apple");
        Assert.That(trie.Remove("app"), Is.False);
        Assert.That(trie.CountPrefix("app"), Is.EqualTo(1));
    }

    [Test]
    public void Find_WalksLetterByLetter()
    {
        var trie = new Trie();
        trie.Insert("cat");
        var node = trie.Root.Children['c'].Children['a'];
        Assert.That(node, Is.SameAs(trie.Find("ca")));
        Assert.That(node.Children['t'].IsWord, Is.True);
        Assert.That(trie.Find("dog"), Is.Null);
    }
}
