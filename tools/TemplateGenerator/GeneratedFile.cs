namespace TemplateGenerator;

/// <summary>
/// One rendered file of a problem folder, with CRLF line endings.
/// </summary>
internal sealed record GeneratedFile(string Name, string Content);
