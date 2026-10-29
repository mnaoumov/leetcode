using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace LeetCode.Base;

/// <summary>
/// The CPU time one thread has used so far, readable from any thread.
/// Windows reports it in clock ticks (about 15.6 ms), which is fine for budgets of 100 ms and more.
/// </summary>
internal sealed class ThreadCpuClock : IDisposable
{
    private const uint ThreadQueryLimitedInformation = 0x0800;

    private readonly ThreadHandle _handle;

    private ThreadCpuClock(ThreadHandle handle) => _handle = handle;

    public static ThreadCpuClock ForCurrentThread()
    {
        var handle = NativeMethods.OpenThread(ThreadQueryLimitedInformation, false, NativeMethods.GetCurrentThreadId());

        if (handle.IsInvalid)
        {
            var error = Marshal.GetLastPInvokeError();
            handle.Dispose();
            throw new Win32Exception(error);
        }

        return new ThreadCpuClock(handle);
    }

    public TimeSpan Elapsed
    {
        get
        {
            if (!NativeMethods.GetThreadTimes(_handle, out _, out _, out var kernelTime, out var userTime))
            {
                throw new Win32Exception(Marshal.GetLastPInvokeError());
            }

            // FILETIME counts 100 ns intervals, the same unit as TimeSpan ticks.
            return TimeSpan.FromTicks(kernelTime + userTime);
        }
    }

    public void Dispose() => _handle.Dispose();

    private sealed class ThreadHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public ThreadHandle() : base(true)
        {
        }

        protected override bool ReleaseHandle() => NativeMethods.CloseHandle(handle);
    }

    private static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern uint GetCurrentThreadId();

        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern ThreadHandle OpenThread(uint desiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool inheritHandle, uint threadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetThreadTimes(ThreadHandle thread, out long creationTime, out long exitTime,
            out long kernelTime, out long userTime);

        [DllImport("kernel32.dll", SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr handle);
    }
}
