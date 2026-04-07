using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.RegularExpressions;
using Scriban;
using JetBrains.Annotations;
using Scriban.Runtime;

namespace TemplateGenerator;

internal abstract partial class GeneratorBase : IGenerator
{
    [GeneratedRegex(@"^(\d+)\.")]
    private static partial Regex ProblemNumberRegex();

    private const string InvalidNamespaceChars = " `-=~!@#$%^&*()+[]{}',.;";
    private const int ProblemNumberLength = 4;
    private const char ReplacementChar = '_';
    private static readonly string LeetCodeFolderPath = Path.GetFullPath(
        Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "LeetCode", "Problems", "!TODO"));

    protected readonly Option<string> TitleOption = new("--title") { Description = "Problem title", Required = true };

    private string Title { get; set; } = string.Empty;
    private string TaskDir { get; set; } = string.Empty;

    [UsedImplicitly]
    public string EscapedTitle { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string Namespace { get; private set; } = string.Empty;

    public abstract string CommandName { get; }
    public abstract string CommandDescription { get; }

    public virtual void ConfigureCommand(Command command)
    {
        command.Add(TitleOption);
    }

    public virtual void SetOptions(ParseResult parseResult)
    {
        var title = parseResult.GetValue(TitleOption)
            ?? throw new InvalidOperationException("Title is required");
        Init(title);
    }

    public void Init(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        Title = title;
        var titleWithUnifiedProblemNumber = ProblemNumberRegex().Replace(Title, match => match.Groups[1].Value.PadLeft(ProblemNumberLength, '0'));
        var validFolderName = ReplaceChars(titleWithUnifiedProblemNumber, Path.GetInvalidFileNameChars().Append('.').ToArray());
        TaskDir = $@"{LeetCodeFolderPath}\{validFolderName}";
        EscapedTitle = $"_{ReplaceChars(validFolderName, InvalidNamespaceChars.ToCharArray())}";
        Namespace = GenerateTemplate("namespace LeetCode.Problems.{{ EscapedTitle }};");
    }

    public abstract void Generate();

    private static string ReplaceChars(string str, char[] chars) => string.Join(ReplacementChar, str.Split(chars));

    protected void GenerateFile(string fileName, string template)
    {
        if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            throw new ArgumentException($"Invalid file name: {fileName}", nameof(fileName));
        }

        Directory.CreateDirectory(TaskDir);
        var content = GenerateTemplate(template);

        // Normalize line endings to CRLF for Windows/Visual Studio
        content = content.Replace("\r\n", "\n").Replace("\n", "\r\n");

        if (!content.EndsWith("\r\n"))
        {
            content += "\r\n";
        }

        File.WriteAllText($@"{TaskDir}\{fileName}", content);
    }

    protected string GenerateTemplate(string template)
    {
        var scriptObject = new ScriptObject();
        scriptObject.Import(this, renamer: member => member.Name);

        var ctx = new TemplateContext
        {
            MemberRenamer = member => member.Name,
            StrictVariables = true
        };

        ctx.PushGlobal(scriptObject);
        return Template.Parse(template).Render(ctx);
    }
}
