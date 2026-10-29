using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

internal class MockFileSystem : IFileSystem
{
    public Func<string, bool> OnDirectoryExists { get; set; } = _ => false;
    public Func<string, string, string[]> OnGetDirectories { get; set; } = (_, _) => [];
    public Func<string, string, string[]> OnGetFiles { get; set; } = (_, _) => [];
    public Func<string, string> OnReadAllText { get; set; } = path => throw new FileNotFoundException(path);

    public bool DirectoryExists(string path) => OnDirectoryExists(path);

    public string[] GetDirectories(string parentPath, string searchPattern) =>
        OnGetDirectories(parentPath, searchPattern);

    public string[] GetFiles(string path, string searchPattern) =>
        OnGetFiles(path, searchPattern);

    public string ReadAllText(string path) => OnReadAllText(path);
}
