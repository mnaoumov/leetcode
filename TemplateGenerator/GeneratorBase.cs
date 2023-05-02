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
    private const string LeetCodeFolderPath = @"F:\Dev\LeetCode\LeetCode";

    private string Title { get; set; } = null!;

    [UsedImplicitly]
    public string Signature { get; private set; } = null!;

    private string TaskDir { get; set; } = null!;

    [UsedImplicitly]
    public string EscapedTitle { get; private set; } = null!;

    [UsedImplicitly]
    public string Namespace { get; private set; } = null!;

    public abstract bool CanGenerate();

    public abstract void Generate();

    public void Init(string title, string signature)
    {
        Title = title;
        Signature = signature;
        var titleWithUnifiedProblemNumber = ProblemNumberRegex().Replace(Title, match => match.Groups[1].Value.PadLeft(ProblemNumberLength, '0'));
        var validFolderName = ReplaceChars(titleWithUnifiedProblemNumber, Path.GetInvalidFileNameChars().Append('.').ToArray());
        TaskDir = $@"{LeetCodeFolderPath}\{validFolderName}";
        EscapedTitle = $"_{ReplaceChars(validFolderName, InvalidNamespaceChars.ToCharArray())}";
        Namespace = GenerateTemplate("""
            namespace LeetCode.{{ EscapedTitle }};
            """);
    }

    private static string ReplaceChars(string str, char[] chars) => string.Join(ReplacementChar, str.Split(chars));

    protected void GenerateFile(string fileName, string template)
    {
        Directory.CreateDirectory(TaskDir);
        var content = GenerateTemplate(template);

        if (!content.EndsWith(Environment.NewLine))
        {
            content += Environment.NewLine;
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
