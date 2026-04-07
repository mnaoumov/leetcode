using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class CSharpClassGenerator : GeneratorBase
{
    [GeneratedRegex(@"public class (.+) \{")]
    private static partial Regex ClassNameRegex();

    [GeneratedRegex(@"(public .+?\(.*?\)) \{")]
    private static partial Regex MethodsRegex();

    [GeneratedRegex(@"\((.*)\)")]
    private static partial Regex ConstructorArgumentsRegex();

    [GeneratedRegex(@"//.*|/\*[\s\S]*?\*/")]
    private static partial Regex CommentsRegex();

    [GeneratedRegex(@"(?m)^Input\:?(?:\r?\n| )(?<Input>.+?)\r?\n(?<Parameters>.+?)(?:\r?\n)+Output\:?(?:\r?\n| )(?<Output>.+?)\r?$")]
    private static partial Regex ExamplesRegex();

    private readonly Option<string?> _codeOption = new("--class-code") { Description = "Class definition code block" };
    private readonly Option<string?> _descriptionOption = new("--description") { Description = "Problem description (used to extract examples)" };

    private string? _code;
    private string? _description;

    [UsedImplicitly]
    public string InterfaceName { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string ClassName { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string[] Methods { get; private set; } = [];

    [UsedImplicitly]
    public string ConstructorArgumentsStr { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string ConstructorArgumentNamesStr { get; private set; } = string.Empty;

    [UsedImplicitly]
    public CSharpClassExample Example { get; private set; } = new();

    public override string CommandName => "csharp-class";
    public override string CommandDescription => "Generate C# class design problem template";

    public override void ConfigureCommand(Command command)
    {
        base.ConfigureCommand(command);
        command.Add(_codeOption);
        command.Add(_descriptionOption);
    }

    public override void SetOptions(ParseResult parseResult)
    {
        base.SetOptions(parseResult);
        _code = parseResult.GetValue(_codeOption);
        _description = parseResult.GetValue(_descriptionOption);
    }

    public override void Generate()
    {
        var rawClassDefinition = _code ?? ConsoleHelper.ReadMultiline("Class definition");
        var classDefinition = CommentsRegex().Replace(rawClassDefinition, "").Trim();
        var examplesStr = _description ?? ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match => new CSharpClassExample
        {
            CommandsStr = match.Groups["Input"].Value,
            ParametersStr = match.Groups["Parameters"].Value,
            OutputStr = match.Groups["Output"].Value
        }).ToArray();

        ClassName = ClassNameRegex().Match(classDefinition).Groups[1].Value;
        InterfaceName = $"I{ClassName}";
        var allMethods = MethodsRegex().Matches(classDefinition).Select(m => m.Groups[1].Value)
            .ToArray();
        var constructor = allMethods.FirstOrDefault(m => m.Contains($"public {ClassName}"))
            ?? throw new InvalidOperationException($"No constructor found for class '{ClassName}'");
        Methods = allMethods.Except(new[] { constructor })
            .Select(m => m.Replace("public ", ""))
            .ToArray();
        ConstructorArgumentsStr = ConstructorArgumentsRegex().Match(constructor).Groups[1].Value;
        ConstructorArgumentNamesStr = string.Join(", ",
            ConstructorArgumentsStr.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(' ')[1]));

        GenerateFile($"{InterfaceName}.cs", """
            {{ Namespace }}

            [PublicAPI]
            public interface {{ InterfaceName }}
            {
            {{~ for method in Methods ~}}
                {{ method }};
            {{~ end ~}}
            }
            """);

        GenerateFile("ISolution.cs", """
            {{ Namespace }}

            [PublicAPI]
            public interface ISolution
            {
                {{ InterfaceName }} Create({{ ConstructorArgumentsStr }});
            }
            """);

        GenerateFile("Solution1.cs", """
            {{ Namespace }}

            /// <summary>
            /// TODO url
            /// </summary>
            [UsedImplicitly]
            public class Solution1 : ISolution
            {
                public {{ InterfaceName }} Create({{ ConstructorArgumentsStr }}) => new {{ ClassName }}({{ ConstructorArgumentNamesStr }});

                private class {{ ClassName }} : {{ InterfaceName }}
                {
                    public {{ ClassName }}({{ ConstructorArgumentsStr }})
                    {
                        throw new NotImplementedException();
                    }
                {{~ for method in Methods ~}}

                    public {{ method }}
                    {
                        throw new NotImplementedException();
                    }
                {{~ end ~}}
                }
            }
            """);

        GenerateFile("Tests.cs", """
            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : ClassDesignTestsBase<ISolution, {{ InterfaceName }}>
            {
            }
            """);

        for (var i = 0; i < examples.Length; i++)
        {
            Example = examples[i];

            GenerateFile($"TestCase{i + 1}.json", """
            {
                "commands": {{ Example.CommandsStr }},
                "parameters": {{ Example.ParametersStr }},
                "output": {{ Example.OutputStr }}
            }
            """);
        }
    }

    public class CSharpClassExample
    {
        [UsedImplicitly]
        public string CommandsStr { get; init; } = string.Empty;

        [UsedImplicitly]
        public string ParametersStr { get; init; } = string.Empty;

        [UsedImplicitly]
        public string OutputStr { get; init; } = string.Empty;
    }
}
