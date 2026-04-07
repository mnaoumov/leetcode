using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LeetCodeExporter;

public static class SolutionTransformer
{
    public static string Transform(string source)
    {
        var tree = CSharpSyntaxTree.ParseText(source);
        var root = tree.GetCompilationUnitRoot();

        var usings = root.Usings;
        var outerClass = root.DescendantNodes().OfType<ClassDeclarationSyntax>().First();

        return IsClassDesign(outerClass)
            ? TransformClassDesign(outerClass, usings)
            : TransformMethod(outerClass, usings);
    }

    private static bool IsClassDesign(ClassDeclarationSyntax outerClass)
    {
        return outerClass.Members
            .OfType<MethodDeclarationSyntax>()
            .Any(m => m.Identifier.Text == "Create");
    }

    private static string TransformMethod(ClassDeclarationSyntax outerClass, SyntaxList<UsingDirectiveSyntax> usings)
    {
        var cleaned = outerClass
            .WithAttributeLists([])
            .WithBaseList(null)
            .WithIdentifier(SyntaxFactory.Identifier("Solution"))
            .WithLeadingTrivia()
            .WithTrailingTrivia();

        cleaned = RemoveDocComments(cleaned);

        return FormatOutput(usings, cleaned);
    }

    private static string TransformClassDesign(ClassDeclarationSyntax outerClass, SyntaxList<UsingDirectiveSyntax> usings)
    {
        var innerClass = outerClass.Members
            .OfType<ClassDeclarationSyntax>()
            .First();

        var newBaseList = RemoveInterfaces(innerClass.BaseList);

        var newModifiers = SyntaxFactory.TokenList(
            SyntaxFactory.Token(SyntaxKind.PublicKeyword));

        var cleaned = innerClass
            .WithModifiers(newModifiers)
            .WithBaseList(newBaseList)
            .WithLeadingTrivia()
            .WithTrailingTrivia();

        cleaned = RemoveDocComments(cleaned);

        return FormatOutput(usings, cleaned);
    }

    private static BaseListSyntax? RemoveInterfaces(BaseListSyntax? baseList)
    {
        if (baseList == null)
        {
            return null;
        }

        var nonInterfaceTypes = baseList.Types
            .Where(t =>
            {
                var name = t.Type.ToString();
                return !name.StartsWith('I') || !char.IsUpper(name.ElementAtOrDefault(1));
            })
            .ToArray();

        if (nonInterfaceTypes.Length == 0)
        {
            return null;
        }

        return baseList.WithTypes(SyntaxFactory.SeparatedList(nonInterfaceTypes));
    }

    private static ClassDeclarationSyntax RemoveDocComments(ClassDeclarationSyntax classDecl)
    {
        var trivia = classDecl.GetLeadingTrivia()
            .Where(t => !t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)
                         && !t.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia))
            .ToList();

        return classDecl.WithLeadingTrivia(trivia);
    }

    private static string FormatOutput(SyntaxList<UsingDirectiveSyntax> usings, ClassDeclarationSyntax classDecl)
    {
        var parts = new List<string>();

        var relevantUsings = usings
            .Where(u => u.Name?.ToString().StartsWith("System") == true)
            .Select(u => u.ToFullString().Trim())
            .ToArray();

        if (relevantUsings.Length > 0)
        {
            parts.Add(string.Join("\n", relevantUsings));
            parts.Add("");
        }

        parts.Add(classDecl.NormalizeWhitespace().ToFullString().Replace("\r\n", "\n"));
        parts.Add("");

        return string.Join("\n", parts);
    }
}
