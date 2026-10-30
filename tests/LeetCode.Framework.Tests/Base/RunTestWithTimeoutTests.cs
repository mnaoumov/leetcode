using System.Diagnostics;
using LeetCode.Base;

namespace LeetCode.Framework.Tests.Base;

public class RunTestWithTimeoutTests : TestsBase
{
    private sealed class TimedTestCase : TestCaseBase
    {
    }

    private static TimedTestCase WithTimeout(int timeoutInMilliseconds) =>
        new() { TimeoutInMilliseconds = timeoutInMilliseconds };

    [Test]
    public void PassesWhenTheActionFinishesInBudget()
    {
        var ran = false;

        RunTestWithTimeout(WithTimeout(200), () => ran = true);

        Assert.That(ran, Is.True);
    }

    [Test]
    public void RunsTheActionOnALargeStack()
    {
        // About 400 bytes a frame: 100 000 frames would overflow a 1 MB or an 8 MB stack.
        RunTestWithTimeout(WithTimeout(5000), () => Assert.That(Recurse(100_000), Is.EqualTo(100_000)));
    }

    private static int Recurse(int depth)
    {
        Span<byte> frame = stackalloc byte[256];
        frame[0] = 1;
        return depth == 0 ? 0 : frame[0] + Recurse(depth - 1);
    }

    [Test]
    public void RethrowsTheActionsException()
    {
        var exception = Assert.Throws<InvalidOperationException>(() =>
            RunTestWithTimeout(WithTimeout(200), () => throw new InvalidOperationException("boom")));

        Assert.That(exception.Message, Is.EqualTo("boom"));
    }

    [Test]
    public void DoesNotCountTimeTheActionSpendsOffTheCpu()
    {
        // Twice the budget in wall-clock time, next to none of it on the CPU: what a starved thread looks like.
        RunTestWithTimeout(WithTimeout(100), () => Thread.Sleep(200));
    }

    [Test]
    public void AbortsAnActionThatSpinsPastItsCpuBudget()
    {
        var stopwatch = Stopwatch.StartNew();

        var exception = Assert.Throws<AssertionException>(() =>
            RunTestWithTimeout(WithTimeout(100), () =>
            {
                while (true)
                {
                    Spin();
                }
            }));

        Assert.That(exception.Message, Does.Contain("timed out after 100 milliseconds of CPU time"));
        Assert.That(stopwatch.Elapsed, Is.LessThan(GetWallClockLimit(TimeSpan.FromMilliseconds(100))));
    }

    private static void Spin() => Thread.SpinWait(1000);

    [Test]
    public void AbortsABlockedActionAtTheWallClockLimit()
    {
        // The CPU clock charges whole clock ticks of about 15.6 ms, so a budget under a few ticks is overrun by a
        // blocked thread whose wake-ups a tick happens to land on, as one did on a loaded machine.
        // Sleeping in short naps leaves the abort a managed point to land at.
        var exception = Assert.Throws<AssertionException>(() =>
            RunTestWithTimeout(WithTimeout(100), () =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                }
            }));

        Assert.That(exception.Message, Does.Contain("so it is blocked"));
    }

    [Test]
    public void FailsAnAsyncActionThatOverrunsItsBudget()
    {
        var exception = Assert.Throws<AssertionException>(() =>
            RunTestWithTimeout(WithTimeout(100), cancellationToken => Task.Delay(Timeout.Infinite, cancellationToken)));

        Assert.That(exception.Message, Does.Contain("timed out after 100 milliseconds"));
    }

    [Test]
    public void PassesAnAsyncActionThatFinishesInBudget()
    {
        RunTestWithTimeout(WithTimeout(1000), _ => Task.Delay(10, CancellationToken.None));
    }
}
