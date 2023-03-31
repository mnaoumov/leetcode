namespace LeetCode;

internal class TempDir : IDisposable
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
        catch
        {
            // Ignore
        }
    }
}