using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace TemplateGenerator;

internal partial class SutGenerator : GeneratorBase
{
    [GeneratedRegex(@"public class (.+) \{")]
    private static partial Regex ClassNameRegex();

    [GeneratedRegex(@"(public .+?\(.*?\)) \{")]
    private static partial Regex MethodsRegex();

    [GeneratedRegex(@"\((.*)\)")]
    private static partial Regex ConstructorArgumentsRegex();

    [GeneratedRegex(@"(?m)^Input\:?(?:\r?\n| )(?<Input>.+?)\r?\n(?<Parameters>.+?)(?:\r?\n)+Output\:?(?:\r?\n| )(?<Output>.+?)\r?$")]
    private static partial Regex ExamplesRegex();

    [UsedImplicitly]
    public string InterfaceName { get; private set; } = null!;

    [UsedImplicitly]
    public string ClassName { get; private set; } = null!;

    [UsedImplicitly]
    public string[] Methods { get; private set; } = null!;

    [UsedImplicitly]
    public string ConstructorArgumentsStr { get; private set; } = null!;

    [UsedImplicitly]
    public string ConstructorArgumentNamesStr { get; private set; } = null!;

    [UsedImplicitly]
    public SutExample Example { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "SUT";

    public override void Generate()
    {
        var sutClassDefinition = ConsoleHelper.ReadMultiline("SUT class definition");
        var examplesStr = ConsoleHelper.ReadMultiline("Examples");

        var examples = ExamplesRegex().Matches(examplesStr).Select(match => new SutExample
        {
            CommandsStr = match.Groups["Input"].Value,
            ParametersStr = match.Groups["Parameters"].Value,
            OutputStr = match.Groups["Output"].Value
        }).ToArray();

        ClassName = ClassNameRegex().Match(sutClassDefinition).Groups[1].Value;
        InterfaceName = $"I{ClassName}";
        Methods = MethodsRegex().Matches(sutClassDefinition).Select(m => m.Groups[1].Value)
            .ToArray();
        var constructor = Methods.First(m => m.Contains($"public {ClassName}"));
        Methods = Methods.Except(new[] { constructor }).ToArray();
        ConstructorArgumentsStr = ConstructorArgumentsRegex().Match(constructor).Groups[1].Value;
        ConstructorArgumentNamesStr = string.Join(", ",
            ConstructorArgumentsStr.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(' ')[1]));

        GenerateFile($"{InterfaceName}.cs", """
            using JetBrains.Annotations;

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
            using JetBrains.Annotations;

            {{ Namespace }}

            [PublicAPI]
            public interface ISolution
            {
                public {{ InterfaceName }} Create({{ ConstructorArgumentsStr }});
            }
            """);

        GenerateFile("Solution1.cs", """
            using JetBrains.Annotations;

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
            using JetBrains.Annotations;

            {{ Namespace }}

            [UsedImplicitly]
            public class Tests : SutTestsBase<ISolution, {{ InterfaceName }}>
            {
            }
            """);

        var testCaseCounter = 0;

        foreach (var example in examples)
        {
            testCaseCounter++;
            Example = example;

            GenerateFile($"TestCase{testCaseCounter}.json", """
            {
                "commands": {{ Example.CommandsStr }},
                "parameters": {{ Example.ParametersStr }},
                "output": {{ Example.OutputStr }}
            }
            """);
        }
    }

    public class SutExample
    {
        [UsedImplicitly]
        public string CommandsStr { get; init; } = null!;

        [UsedImplicitly]
        public string ParametersStr { get; init; } = null!;

        [UsedImplicitly]
        public string OutputStr { get; init; } = null!;
    }
}
