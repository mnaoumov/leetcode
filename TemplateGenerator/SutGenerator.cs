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

    [GeneratedRegex(@"\r\nInput\r\n(.+?)\r\n(.+?)\r\nOutput\r\n(.+?)\r\n")]
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

    private SutExample[] Examples { get; set; } = null!;

    [UsedImplicitly]
    public SutExample Example { get; private set; } = null!;

    public override bool CanGenerate() => Signature == "SUT";

    public override void Generate()
    {
        var sutClassDefinition = ConsoleHelper.ReadMultiline("SUT class definition");
        var examplesStr = ConsoleHelper.ReadMultiline("Examples");

        Examples = ExamplesRegex().Matches(examplesStr).Select(match => new SutExample
        {
            CommandsStr = match.Groups[1].Value,
            ParametersStr = match.Groups[2].Value,
            OutputStr = match.Groups[3].Value
        }).ToArray();

        var sutClassName = ClassNameRegex().Match(sutClassDefinition).Groups[1].Value;
        InterfaceName = $"I{sutClassName}";
        ClassName = $"{sutClassName}1";
        Methods = MethodsRegex().Matches(sutClassDefinition).Select(m => m.Groups[1].Value)
            .ToArray();
        var constructor = Methods.First(m => m.Contains($"public {sutClassName}"));
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

        GenerateFile($"{ClassName}.cs", """
            using JetBrains.Annotations;

            {{ Namespace }}

            /// <summary>
            /// TODO url
            /// </summary>
            public class {{ ClassName }} : {{ InterfaceName }}
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
            public class Solution1
            {
                public {{ InterfaceName }} Create({{ ConstructorArgumentsStr }}) => new {{ ClassName }}({{ ConstructorArgumentNamesStr }});
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

        foreach (var example in Examples)
        {
            testCaseCounter++;
            Example = example;

            GenerateFile($"TestCase{testCaseCounter}.json", """
            {
                commands: {{ Example.CommandsStr }},
                parameters: {{ Example.ParametersStr }},
                output: {{ Example.OutputStr }}
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
