namespace LeetCode.Base;

/// <summary>
/// Names the folder of a problem: <paramref name="relativePath"/>, relative to the problems project, holds the
/// sources declaring <paramref name="namespaceName"/>. The problems assembly's source generator emits one per problem.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class ProblemDirectoryAttribute(string namespaceName, string relativePath) : Attribute
{
    public string NamespaceName { get; } = namespaceName;

    public string RelativePath { get; } = relativePath;
}
