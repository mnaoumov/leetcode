const NBSP = '\u00A0';
const PROJECT_PATH = 'F:\\\\dev\\\\leetcode\\\\TemplateGenerator\\\\TemplateGenerator.csproj';

async function main(): Promise<void> {
  const title = getTextContent('.text-title-large').replace(/^Q\d/g, '0000');
  const code = getCodeContent();
  const description = getTextContent('[data-track-load=description_content]');

  const command = buildCommand(title, code, description);

  await navigator.clipboard.writeText(command);
  alert('Copied: ' + (isClassDesign(code) ? 'csharp-class' : 'csharp-method'));
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

function isClassDesign(code: string): boolean {
  return !/\bclass\s+Solution\b/.test(code);
}

function buildCommand(title: string, code: string, description: string): string {
  const prefix = `dotnet run --project ${PROJECT_PATH} --`;

  if (isClassDesign(code)) {
    return `${prefix} csharp-class --title "${escapeArg(title)}" --class-code "${escapeArg(code)}" --description "${escapeArg(description)}"`;
  }

  const codeLines = code.split('\n');
  const methodLine = codeLines.find(l => l.trim().startsWith('public') && !l.includes('class '));
  const signature = (methodLine ?? '').trim().replace(/ \{$/g, '');
  return `${prefix} csharp-method --title "${escapeArg(title)}" --method-signature "${escapeArg(signature)}" --description "${escapeArg(description)}"`;
}

main();
