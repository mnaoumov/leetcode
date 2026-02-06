namespace LeetCode.Helpers;

internal sealed class TempDir : IDisposable
{
    public string Path { get; }

    public TempDir()
    {
        Path = $"{System.IO.Path.GetTempPath()}{Guid.NewGuid()}";
        Directory.CreateDirectory(Path);
    }

    public void Dispose()
    {
        try
        {
            Directory.Delete(Path, true);
        }
#pragma warning disable CA1031
        catch
#pragma warning restore CA1031
        {
            // Ignore
        }
    }
}
