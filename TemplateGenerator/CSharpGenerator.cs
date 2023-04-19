using System.Text.RegularExpressions;

namespace TemplateGenerator;

internal partial class CSharpGenerator : GeneratorBase
{
    [GeneratedRegex("^public (?<OutputType>\\S+) (?<MethodName>\\S+?)\\s*\\((?<Arguments>.+)?\\)$")]
    private static partial Regex SignatureRegex();

    public override bool CanGenerate() => SignatureRegex().IsMatch(Signature);

    public override void Generate()
    {
        throw new NotImplementedException();
    }
}