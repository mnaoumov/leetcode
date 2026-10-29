namespace LeetCodeExporter;

public interface IFileSystem
{
    bool DirectoryExists(string path);
    string[] GetDirectories(string parentPath, string searchPattern);
    string[] GetFiles(string path, string searchPattern);
    string ReadAllText(string path);
}
