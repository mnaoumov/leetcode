namespace LeetCode.Problems._1166_Design_File_System;

[PublicAPI]
public interface IFileSystem
{
    bool CreatePath(string path, int value);
    int Get(string path);
}
