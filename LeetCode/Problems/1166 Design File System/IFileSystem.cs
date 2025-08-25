namespace LeetCode.Problems._1166_Design_File_System;

[PublicAPI]
public interface IFileSystem
{
    public bool CreatePath(string path, int value);
    public int Get(string path);
}
