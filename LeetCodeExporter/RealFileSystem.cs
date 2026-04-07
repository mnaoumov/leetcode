namespace LeetCodeExporter;

public class RealFileSystem : IFileSystem
{
    public bool DirectoryExists(string path) => Directory.Exists(path);

    public string[] GetDirectories(string parentPath, string searchPattern) =>
        Directory.GetDirectories(parentPath, searchPattern);

    public string[] GetFiles(string path, string searchPattern) =>
        Directory.GetFiles(path, searchPattern);

    public string ReadAllText(string path) => File.ReadAllText(path);
}
