namespace TemplateGenerator;

internal interface IGenerator
{
    bool CanGenerate();
    void Generate(GeneratorOptions options);
    void Init(string title, string signature);
}
