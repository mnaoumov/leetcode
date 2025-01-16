namespace TemplateGenerator;

internal interface IGenerator
{
    bool CanGenerate();
    void Generate(string? examplesStr);
    void Init(string title, string signature);
}
