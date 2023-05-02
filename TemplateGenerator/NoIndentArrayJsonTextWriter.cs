using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TemplateGenerator;

public class NoIndentArrayJsonTextWriter : JsonTextWriter
{
    private NoIndentArrayJsonTextWriter(TextWriter writer) : base(writer)
    {
    }

    protected override void WriteIndent()
    {
        if (WriteState != WriteState.Array)
        {
            base.WriteIndent();
        }
    }

    public static string Indent(JToken token)
    {
        using var sw = new StringWriter();
        using var jw = new NoIndentArrayJsonTextWriter(sw);
        jw.Formatting = Formatting.Indented;
        token.WriteTo(jw);
        return sw.ToString();
    }
}