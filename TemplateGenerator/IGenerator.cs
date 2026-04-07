namespace TemplateGenerator;

internal interface IGenerator
{
    bool CanGenerate();
    void Generate(string[] args);
    void Init(string title, string signature);
}
