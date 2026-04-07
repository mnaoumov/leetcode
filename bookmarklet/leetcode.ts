const NBSP = '\u00A0';
const PROJECT_PATH = 'F:\\\\dev\\\\leetcode\\\\TemplateGenerator\\\\TemplateGenerator.csproj';

async function main(): Promise<void> {
  const title = getTextContent('.text-title-large').replace(/^Q\d/g, '0000');
  const code = getCodeContent();
  const description = getTextContent('[data-track-load=description_content]');

  const command = buildCommand(title, code, description);
  const isClassDesign = code.split('\n')[0].trim().startsWith('class ');

  await navigator.clipboard.writeText(command);
  alert('Copied: ' + (isClassDesign ? 'csharp-class' : 'csharp-method'));
}

function fixString(text: string): string {
  return text.replaceAll(NBSP, ' ').replaceAll('\n', '\r\n');
}

function escapeArg(text: string): string {
  return text.replace(/"/g, '`"').replace(/\r/g, '`r').replace(/\n/g, '`n');
}

function getTextContent(selector: string): string {
  const element = document.querySelector(selector);
  if (!element) {
    throw new Error(`Element not found: ${selector}`);
  }
  return fixString((element as HTMLElement).innerText);
}

function getCodeContent(): string {
  const element = document.querySelector('.view-lines')
    ?? document.querySelector('[contenteditable].cm-content.cm-lineWrapping');
  if (!element) {
    throw new Error('Code element not found');
  }
  return fixString((element as HTMLElement).innerText);
}

function buildCommand(title: string, code: string, description: string): string {
  const codeLines = code.split('\n');
  const isClassDesign = codeLines[0].trim().startsWith('class ');
  const prefix = `dotnet run --project ${PROJECT_PATH} --`;

  if (isClassDesign) {
    return `${prefix} csharp-class --title "${escapeArg(title)}" --class-code "${escapeArg(code)}" --description "${escapeArg(description)}"`;
  }

  const signature = codeLines[1].trim().replace(/ \{$/g, '');
  return `${prefix} csharp-method --title "${escapeArg(title)}" --method-signature "${escapeArg(signature)}" --description "${escapeArg(description)}"`;
}

main();
