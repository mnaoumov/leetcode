using System.CommandLine;

namespace TemplateGenerator;

internal static class Program
{
    public static int Main(string[] args)
    {
        var titleOption = new Option<string?>("--title", "-t") { Description = "Problem title" };
        var signatureOption = new Option<string?>("--signature", "-s") { Description = "Method signature or generator type (CLASS, SQL, JS)" };
        var descriptionOption = new Option<string?>("--description", "-d") { Description = "Problem description text (used to extract examples)" };
        var codeOption = new Option<string?>("--code", "-c") { Description = "Code block (used as class definition for CLASS generator)" };

        var rootCommand = new RootCommand("LeetCode problem template generator")
        {
            titleOption,
            signatureOption,
            descriptionOption,
            codeOption
        };

        rootCommand.SetAction(result =>
        {
            var title = result.GetValue(titleOption);
            var signature = result.GetValue(signatureOption);
            var description = result.GetValue(descriptionOption);
            var code = result.GetValue(codeOption);

            Generator.Generate(title, signature, new GeneratorOptions
            {
                Description = description,
                Code = code
            });
        });

        return rootCommand.Parse(args).Invoke();
    }
}
