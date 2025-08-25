namespace LeetCode.Problems._1166_Design_File_System;

/// <summary>
/// https://leetcode.com/problems/design-file-system/submissions/1735548340/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFileSystem Create() => new FileSystem();

    private class FileSystem : IFileSystem
    {
        private readonly Dictionary<string, int> _map = new();

        public bool CreatePath(string path, int value)
        {
            if (_map.ContainsKey(path))
            {
                return false;
            }

            var lastSlashIndex = path.LastIndexOf('/');
            var parentPath = path[..lastSlashIndex];

            if (parentPath != "" && !_map.ContainsKey(parentPath))
            {
                return false;
            }

            _map[path] = value;
            return true;
        }

        public int Get(string path) => _map.GetValueOrDefault(path, -1);
    }
}
