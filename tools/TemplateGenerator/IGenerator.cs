using System.CommandLine;
using System.CommandLine.Parsing;

namespace TemplateGenerator;

internal interface IGenerator
{
    string CommandName { get; }
    string CommandDescription { get; }
    void ConfigureCommand(Command command);
    void SetOptions(ParseResult parseResult);
    void Init(string title);
    void Generate();
}
