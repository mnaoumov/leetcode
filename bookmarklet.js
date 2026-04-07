(async () => {
    const nbsp = '\u00A0';

    function fixString(text) {
        return text.replaceAll(nbsp, ' ').replaceAll('\n', '\r\n');
    }

    function escapeArg(text) {
        return text.replace(/"/g, '`"').replace(/\r/g, '`r').replace(/\n/g, '`n');
    }

    const title = fixString(document.querySelector('.text-title-large').innerText).replace(/^Q\d/g, '0000');
    const codeElement = document.querySelector('.view-lines') ?? document.querySelector('[contenteditable].cm-content.cm-lineWrapping');
    const code = fixString(codeElement.innerText);
    const description = fixString(document.querySelector('[data-track-load=description_content]').innerText);

    const codeLines = code.split('\n');
    const isClassDesign = codeLines[0].trim().startsWith('class ');

    const project = 'F:\\\\dev\\\\leetcode\\\\TemplateGenerator\\\\TemplateGenerator.csproj';
    let command;

    if (isClassDesign) {
        command = `dotnet run --project ${project} -- csharp-class --title "${escapeArg(title)}" --class-code "${escapeArg(code)}" --description "${escapeArg(description)}"`;
    } else {
        const signature = codeLines[1].trim().replace(/ \{$/g, '');
        command = `dotnet run --project ${project} -- csharp-method --title "${escapeArg(title)}" --method-signature "${escapeArg(signature)}" --description "${escapeArg(description)}"`;
    }

    await navigator.clipboard.writeText(command);
    alert('Copied: ' + (isClassDesign ? 'csharp-class' : 'csharp-method'));
})();
