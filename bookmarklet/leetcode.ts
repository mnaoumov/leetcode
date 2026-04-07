const PROJECT_PATH = 'F:\\\\dev\\\\leetcode\\\\TemplateGenerator\\\\TemplateGenerator.csproj';

// Characters used by LeetCode's Monaco editor as visual markers
const EDITOR_ARTIFACTS = /[\u00A0\u00B7\u200C]/g;

async function main(): Promise<void> {
  const title = getTextContent('.text-title-large').replace(/^Q\d/g, '0000');
  const code = getCodeContent();
  const description = getTextContent('[data-track-load=description_content]');

  const command = buildCommand(title, code, description);

  await navigator.clipboard.writeText(command);
  alert('Copied: ' + (isClassDesign(code) ? 'csharp-class' : 'csharp-method'));
}

function fixString(text: string): string {
  return text.replace(EDITOR_ARTIFACTS, '').replaceAll('\n', '\r\n');
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
  // Try to get code from Monaco's internal model (most reliable, no virtualization issues)
  const monacoEditor = (window as any).monaco?.editor?.getEditors?.()?.[0];
  if (monacoEditor) {
    return fixString(monacoEditor.getValue());
  }

  // Fallback: Monaco editor stores each line in a separate .view-line div
  const viewLines = document.querySelector('.view-lines');
  if (viewLines) {
    const lines = Array.from(viewLines.querySelectorAll('.view-line'));
    lines.sort((a, b) => {
      const topA = parseFloat((a as HTMLElement).style.top);
      const topB = parseFloat((b as HTMLElement).style.top);
      return topA - topB;
    });
    const text = lines.map(l => (l as HTMLElement).innerText).join('\n');
    return fixString(text);
  }

  // CodeMirror fallback
  const cmElement = document.querySelector('[contenteditable].cm-content.cm-lineWrapping');
  if (cmElement) {
    return fixString((cmElement as HTMLElement).innerText);
  }

  throw new Error('Code element not found');
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
