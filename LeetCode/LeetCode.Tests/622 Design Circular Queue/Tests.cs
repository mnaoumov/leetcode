using LeetCode._622_Design_Circular_Queue;
using NUnit.Framework;

namespace LeetCode.Tests._622_Design_Circular_Queue;

[TestFixtureSource(nameof(Solutions))]
public class Tests : TestsBase<ISolution>
{
    public Tests(ISolution solution) : base(solution)
    {
    }

    [Test]
    public void Example1()
    {
        var sut = Solution.Create(3);
        Assert.That(sut.EnQueue(1), Is.True);
        Assert.That(sut.EnQueue(2), Is.True);
        Assert.That(sut.EnQueue(3), Is.True);
        Assert.That(sut.EnQueue(4), Is.False);
        Assert.That(sut.Rear(), Is.EqualTo(3));
        Assert.That(sut.IsFull(), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(4), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(4));
    }

    [Test]
    public void Test1()
    {
        var sut = Solution.Create(3);
        Assert.That(sut.EnQueue(2), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(2));
        Assert.That(sut.Front(), Is.EqualTo(2));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(-1));
        Assert.That(sut.DeQueue(), Is.False);
        Assert.That(sut.Front(), Is.EqualTo(-1));
        Assert.That(sut.EnQueue(4), Is.True);
        Assert.That(sut.EnQueue(2), Is.True);
        Assert.That(sut.EnQueue(2), Is.True);
        Assert.That(sut.EnQueue(3), Is.False);
    }

    [Test]
    public void Test2()
    {
        var sut = Solution.Create(81);
        Assert.That(sut.EnQueue(69), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(92), Is.True);
        Assert.That(sut.EnQueue(12), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.IsFull(), Is.False);
        Assert.That(sut.IsFull(), Is.False);
        Assert.That(sut.Front(), Is.EqualTo(12));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(28), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(28));
        Assert.That(sut.EnQueue(13), Is.True);
        Assert.That(sut.EnQueue(45), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(45));
        Assert.That(sut.Rear(), Is.EqualTo(45));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(24), Is.True);
        Assert.That(sut.EnQueue(27), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(27));
        Assert.That(sut.Rear(), Is.EqualTo(27));
        Assert.That(sut.Front(), Is.EqualTo(13));
        Assert.That(sut.Rear(), Is.EqualTo(27));
        Assert.That(sut.Rear(), Is.EqualTo(27));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(88), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(88));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(88));
        Assert.That(sut.Rear(), Is.EqualTo(88));
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.EnQueue(53), Is.True);
        Assert.That(sut.EnQueue(39), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.EnQueue(28), Is.True);
        Assert.That(sut.EnQueue(66), Is.True);
        Assert.That(sut.EnQueue(17), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.IsEmpty(), Is.False);
        Assert.That(sut.EnQueue(47), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(47));
        Assert.That(sut.EnQueue(87), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.EnQueue(92), Is.True);
        Assert.That(sut.EnQueue(94), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(24));
        Assert.That(sut.EnQueue(59), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(99), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(53));
        Assert.That(sut.EnQueue(84), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(84));
        Assert.That(sut.IsEmpty(), Is.False);
        Assert.That(sut.Front(), Is.EqualTo(53));
        Assert.That(sut.EnQueue(52), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(53));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(86), Is.True);
        Assert.That(sut.EnQueue(30), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Front(), Is.EqualTo(66));
        Assert.That(sut.Front(), Is.EqualTo(66));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.IsEmpty(), Is.False);
        Assert.That(sut.EnQueue(45), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(45));
        Assert.That(sut.Front(), Is.EqualTo(17));
        Assert.That(sut.EnQueue(83), Is.True);
        Assert.That(sut.IsEmpty(), Is.False);
        Assert.That(sut.Front(), Is.EqualTo(17));
        Assert.That(sut.Front(), Is.EqualTo(17));
        Assert.That(sut.EnQueue(22), Is.True);
        Assert.That(sut.EnQueue(77), Is.True);
        Assert.That(sut.EnQueue(23), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(23));
        Assert.That(sut.Front(), Is.EqualTo(17));
        Assert.That(sut.Front(), Is.EqualTo(17));
        Assert.That(sut.EnQueue(14), Is.True);
        Assert.That(sut.IsEmpty(), Is.False);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.EnQueue(90), Is.True);
        Assert.That(sut.EnQueue(57), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(57));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(57));
        Assert.That(sut.Front(), Is.EqualTo(87));
        Assert.That(sut.EnQueue(34), Is.True);
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(34));
        Assert.That(sut.Front(), Is.EqualTo(92));
        Assert.That(sut.Rear(), Is.EqualTo(34));
        Assert.That(sut.DeQueue(), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(34));
        Assert.That(sut.Rear(), Is.EqualTo(34));
        Assert.That(sut.EnQueue(49), Is.True);
        Assert.That(sut.EnQueue(59), Is.True);
        Assert.That(sut.Rear(), Is.EqualTo(59));
        Assert.That(sut.EnQueue(71), Is.True);
    }
}