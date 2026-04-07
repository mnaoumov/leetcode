using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class ClassDesignGenerator : GeneratorBase
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
    public ClassDesignExample Example { get; private set; } = new();

    public override bool CanGenerate() => Signature.Equals("CLASS", StringComparison.OrdinalIgnoreCase);

    public override void Generate(string? examplesStr)
    {
        var rawClassDefinition = ConsoleHelper.ReadMultiline("Class definition");
        var classDefinition = CommentsRegex().Replace(rawClassDefinition, "").Trim();
        examplesStr ??= ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match => new ClassDesignExample
        {
            CommandsStr = match.Groups["Input"].Value,
            ParametersStr = match.Groups["Parameters"].Value,
            OutputStr = match.Groups["Output"].Value
        }).ToArray();

        ClassName = ClassNameRegex().Match(classDefinition).Groups[1].Value;
        InterfaceName = $"I{ClassName}";
        Methods = MethodsRegex().Matches(classDefinition).Select(m => m.Groups[1].Value)
            .ToArray();
        var constructor = Methods.FirstOrDefault(m => m.Contains($"public {ClassName}"))
            ?? throw new InvalidOperationException($"No constructor found for class '{ClassName}'");
        Methods = Methods.Except(new[] { constructor }).ToArray();
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
                
                    {{ method }}
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

    public class ClassDesignExample
    {
        [UsedImplicitly]
        public string CommandsStr { get; init; } = string.Empty;

        [UsedImplicitly]
        public string ParametersStr { get; init; } = string.Empty;

        [UsedImplicitly]
        public string OutputStr { get; init; } = string.Empty;
    }
}
