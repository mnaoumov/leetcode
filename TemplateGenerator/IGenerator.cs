namespace TemplateGenerator;

internal interface IGenerator
{
    bool CanGenerate();
    void Generate();
    void Init(string title, string signature);
}