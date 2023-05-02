namespace TemplateGenerator;

public static class ConsoleHelper
{
    public static string Read(string prompt)
    {
        Console.Write($"Enter {prompt}: ");
        return Console.ReadLine()!;
    }

    public static string ReadMultiline(string prompt)
    {
        Console.WriteLine($"Enter multiline {prompt} finishing with Ctrl + Z");
        var lines = new List<string>();

        while (Console.ReadLine() is { } line)
        {
            lines.Add(line);
        }

        return string.Join(Environment.NewLine, lines.ToArray());
    }
}