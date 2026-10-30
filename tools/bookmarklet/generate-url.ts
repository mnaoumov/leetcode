import { execSync } from 'node:child_process';
import path from 'node:path';

// node runs this file as an ES module, which has no __dirname.
const scriptDir = import.meta.dirname;
const entryPath = path.join(scriptDir, 'leetcode.ts');
// Baked into the bookmarklet, so the copied command follows the repo wherever it is cloned.
const projectPath = path.resolve(scriptDir, '..', 'TemplateGenerator', 'TemplateGenerator.csproj').replaceAll('\\', '/');

const result = execSync(`npx esbuild "${entryPath}" --bundle --format=iife --minify --target=es2022 "--define:PROJECT_PATH=\\"${projectPath}\\""`, {
  encoding: 'utf8'
});

const bookmarklet = 'javascript:' + encodeURIComponent(result.trim());
execSync('clip', { input: bookmarklet });
console.log('Bookmarklet URL copied to clipboard');
