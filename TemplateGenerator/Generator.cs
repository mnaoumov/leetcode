using System.Text;
using System.Text.RegularExpressions;
using Fluid;
using Fluid.Values;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TemplateGenerator;

public partial class Generator
{
    [GeneratedRegex(@"^(\d+)\.")]
    private static partial Regex TitleNumberRegex();

    [GeneratedRegex("[' \\-]")]
    private static partial Regex InvalidTitleCharactersRegex();

    [GeneratedRegex("\".*\"")]
    private static partial Regex TwoQuotesRegex();

    [GeneratedRegex(@"^IList|\[\]$")]
    private static partial Regex IsCollectionTypeRegex();

    [GeneratedRegex(@"^public (?<OutputType>\S+) (?<MethodName>\S+?)\s*\((?<Arguments>.+)?\)$")]
    private static partial Regex SignatureRegex();

    private string TaskDir { get; set; }
    private string EscapedTitle { get; set; }
    private string Signature { get; set; }

    public void Generate()
    {
        var title = Input("title");
        Signature = Input("test method signature or SUT or SQL");
        title = TitleNumberRegex().Replace(title, match => match.Groups[1].Value.PadLeft(4, '0'));
        TaskDir = $@"F:\Dev\LeetCode\LeetCode\{title}";
        Directory.CreateDirectory(TaskDir);
        EscapedTitle = "_" + InvalidTitleCharactersRegex().Replace(title, "_");

        switch (Signature)
        {
            case "SQL":
                GenerateSql();
                return;
            case "SUT":
                GenerateSut();
                return;
            default:
                GenerateCSharp();
                return;
        }
    }

    private void GenerateCSharp()
    {
        var match = SignatureRegex().Match(Signature);

        if (!match.Success)
        {
            throw new Exception("Wrong signature");
        }

        var outputType = match.Groups["OutputType"].Value;
        var methodName = match.Groups["MethodName"].Value;
        var arguments = match.Groups["Arguments"].Value.Split(", ").Append($"{outputType} output").Select(x =>
        {
            var parts = x.Split(' ');
            var originalType = parts[0];
            var jsonName = parts[1];
            var name = ToPascalCase(jsonName);
            string type;
            string argumentStr;

            switch (originalType)
            {
                case "ListNode":
                    type = "int[]";
                    argumentStr = $"ListNode.Create(testCase.{name})";
                    break;
                case "TreeNode":
                    type = "int?[]";
                    argumentStr = $"TreeNode.Create(testCase.{name})";
                    break;
                default:
                    type = originalType;
                    argumentStr = $"testCase.{name}";
                    break;
            }

            return (type: type, name: name, jsonName: jsonName, argumentStr: argumentStr);
        }).ToArray();

        var examples = InputMultiline("Examples");
        var exampleObjs = new List<(string commands, List<string> arguments, string output)>();

        var exampleObj = (commands: "", arguments: "", output: "");

        var exampleLines = examples.Split("\r\n");
        var lineIndex = -1;

        var exampleArguments = new List<string>();

        foreach (var line in exampleLines)
        {
            lineIndex++;

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            if (line.StartsWith("Input: "))
            {
                var isInQuotedString = false;
                var parts = new List<string>();

                foreach (var part in line.Split(", "))
                {
                    var hasQuote = part.Contains('"');
                    var hasTwoQuotes = TwoQuotesRegex().IsMatch(part);

                    if (!isInQuotedString)
                    {
                        parts.Add(part);
                        isInQuotedString = hasQuote && !hasTwoQuotes;
                    }
                    else
                    {
                        parts[^1] += $", {part}";

                        if (hasQuote)
                        {
                            isInQuotedString = false;
                        }
                    }
                }

                exampleArguments = parts.Select(part => part.Split(" = ")[1]).ToList();
            }
            else if (line.StartsWith("Output: "))
            {
                var exampleOutput = line.Replace("Output: ", "");
                exampleArguments.Add(exampleOutput);
                exampleObjs.Add((commands: "", arguments: exampleArguments, output: ""));
            }
        }

        GenerateFile("ISolution.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            [PublicAPI]
            public interface ISolution
            {
                {%= signature %};
            }

            """,
            new
            {
                escapedTitle = EscapedTitle,
                signature = Signature
            });

        GenerateFile("Solution1.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            [PublicAPI]
            public interface Solution1 : ISolution
            {
                {{ signature }}
                {
                    throw new NotImplementedException();
                }
            }

            """,
            new
            {
                escapedTitle = EscapedTitle,
                signature = Signature
            });

        var isCollectionOutput = IsCollectionTypeRegex().IsMatch(outputType);

        string invokeSolutionCodeStr = "";
        var parser = new FluidParser();
        var template = parser.Parse("""
            solution.{{ methodName }}(
                {{- for argument in arguments -}}
                    {{- if argument.name != "Output" -}}
                        {{- argument.argumentStr }}{% unless forloop.last %},{% endunless -%}
                    {{- endif -}}
                {{- endfor -}}
            )
            """);

        GenerateFile("Tests.cs", """
            {%- unless isCollectionOutput) -%}
            using NUnit.Framework;
            {%- endunless %}
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            [UsedImplicitly]
            public class Tests : TestsBase<ISolution, Tests.TestCase>
            {
                protected override void TestImpl(ISolution solution, TestCase testCase)
                {
                    {% if isCollectionOutput %>
                    AssertCollectionEqualWithDetails({{ invokeSolutionCodeStr }}, {{ arguments[-1].argumentStr }});
                    {% else %}
                    Assert.That({{ $invokeSolutionCodeStr }}, Is.EqualTo({{ $arguments[-1].argumentStr }}));
                    {% endif %}
                }

                public class TestCase : TestCaseBase
                {
                    {% for argument in arguments %}
                    public {{ argument.type }} {{ argument.name %} { get; [UsedImplicitly] init; }{%= initStringIfNeeded(argument.type) %}
                    {% endfor %}
                }
            }

            """,
            new
            {
                escapedTitle = EscapedTitle,
                isCollectionOutput,
                invokeSolutionCodeStr,
                arguments,
                initStringIfNeeded = new FunctionValue((args, _) =>
                {
                    var firstArg = args.At(0).ToStringValue();
                    return new StringValue(InitStringIfNeeded(firstArg));
                })
            });
    }

    private void GenerateSut()
    {
        var examples = InputMultiline("Examples");
        var sutClassDefinition = InputMultiline("SUT class definition");
        var sutClassName = Regex.Match(sutClassDefinition, @"public class (.+) \{").Groups[1].Value;
        var sutInterfaceName = 'I' + sutClassName;

        var sutMethods = Regex.Matches(sutClassDefinition, @"(public .+?\(.*?\)) \{")
            .Select(match => match.Groups[1].Value).ToArray();

        var constructor = sutMethods.First(m => m.Contains($"public {sutClassName}"));

        sutMethods = sutMethods.Except(new[] { constructor }).ToArray();

        var sutArguments = Regex.Match(constructor, @"\((.*)\)").Groups[1].Value;

        var sutArgumentNamesStr = string.Join(",",
            sutArguments.Split(", ").Where(x => !string.IsNullOrEmpty(x)).Select(x => x.Split(' ')[1]));

        GenerateFile($"{sutInterfaceName}.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            [PublicAPI]
            public interface {{ sutInterfaceName }}
            {
            {%- for sutMethod in sutMethods %}
                {{ sutMethod }};
            {%- endfor %}
            }
            """,
            new
            {
                escapedTitle = EscapedTitle,
                sutInterfaceName,
                sutMethods
            });

        GenerateFile($"{sutClassName}1.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            /// <summary>
            /// 
            /// </summary>
            public class {{ sutClassName }}1 : {{ sutInterfaceName }}
            {
                public {{ sutClassName }}1({{ sutArguments }})
                {
                    throw new NotImplementedException();
                }
            {%- for sutMethod in sutMethods %}

                {{ sutMethod }}
                {
                    throw new NotImplementedException();
                }
            {%- endfor %}
            }
            """,
            new
            {
                escapedTitle = EscapedTitle,
                sutClassName,
                sutInterfaceName,
                sutArguments,
                sutMethods
            });

        GenerateFile("ISolution.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            [PublicAPI]
            public interface ISolution
            {
                public {{ sutInterfaceName }} Create({{ sutArguments }})";
            }

            """,
            new
            {
                escapedTitle = EscapedTitle,
                sutInterfaceName,
                sutArguments
            });

        GenerateFile("Solution1.cs", """
            using JetBrains.Annotations;

            namespace LeetCode.{{ escapedTitle }};

            /// <summary>
            /// 
            /// </summary>
            [PublicAPI]
            public class Solution1 : ISolution
            {
                public {{ sutInterfaceName }} Create({{ sutArguments }})
                {
                    return new {{ sutClassName }}1({{ sutArgumentNamesStr }});
                }
            }

            """,
            new
            {
                escapedTitle = EscapedTitle,
                sutInterfaceName,
                sutArguments,
                sutClassName,
                sutArgumentNamesStr
            });

        var exampleObjs = new List<(string commands, string arguments, string output)>();

        var exampleObj = (commands: "", arguments: "", output: "");

        var exampleLines = examples.Split("\r\n");
        var lineIndex = -1;

        foreach (var line in exampleLines)
        {
            lineIndex++;

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            switch (line)
            {
                case "Input":
                    exampleObj.commands = exampleLines[lineIndex + 1];
                    exampleObj.arguments = exampleLines[lineIndex + 2];
                    break;
                case "Output":
                    exampleObj.output = exampleLines[lineIndex + 1];
                    exampleObjs.Add(exampleObj);
                    break;
            }
        }

        var arguments = new[]
        {
            (type: "string[]", jsonName: "commands"),
            (type: "object[][]", jsonName: "parameters"),
            (type: "object[]", jsonName: "output")
        };
    }

    private void GenerateFile(string fileName, string templateStr, object model)
    {
        var parser = new FluidParser();
        var template = parser.Parse(templateStr);
        File.WriteAllText($@"{TaskDir}\{fileName}", template.Render(new TemplateContext(model)));
    }

    private void GenerateSql()
    {
        GenerateFile("Tests.cs", """
            using JetBrains.Annotations;
            
            namespace LeetCode.{{ escapedTitle }};
            
            [UsedImplicitly]
            public class Tests : SelectSqlTestsBase<Tests>
            {
            }
            
            """,
            new
            {
                escapedTitle = EscapedTitle
            });

        var setupScript = InputMultiline("SetUp script");
        File.WriteAllText($@"{TaskDir}\SetUp.sql", setupScript);
        File.WriteAllText($@"{TaskDir}\Solution1.sql", """
            -- TODO url

            SELECT 1;

            """);

        var testCaseJsons = InputMultiline("Test cases").Split("\r\n");
        var expectedOutputJsons = InputMultiline("Expected outputs").Split("\r\n");

        for (var i = 0; i < testCaseJsons.Length; i++)
        {
            var testCase = JsonConvert.DeserializeObject<JObject>(testCaseJsons[i])!;
            testCase.Add("output", JsonConvert.DeserializeObject<JObject>(expectedOutputJsons[i]));
            File.WriteAllText($@"{TaskDir}\TestCase{i + 1}.json", testCase.ToString(Formatting.Indented));
        }
    }

    private static string InputMultiline(string prompt)
    {
        Console.WriteLine($"Enter multiline {prompt} ending with Ctrl + Z:");
        var sb = new StringBuilder();

        while (Console.ReadLine() is { } line)
        {
            sb.AppendLine(line);
        }

        return sb.ToString();
    }

    private static string Input(string prompt)
    {
        Console.Write($"Enter {prompt}: ");
        return Console.ReadLine()!;
    }

    private static string ToPascalCase(string str) => str == "" ? "" : $"{char.ToUpper(str[0])}{str[1..]}";

    private static string InitStringIfNeeded(string type)
    {
        switch (type)
        {
            case "int":
            case "long":
            case "bool":
                return "";
            default:
                return " = null!";
        }
    }
}
