import { execSync } from 'node:child_process';
import path from 'node:path';

const result = execSync(`npx esbuild ${path.join(__dirname, 'leetcode.ts')} --bundle --format=iife --minify --target=es2020`, {
    encoding: 'utf8'
});

const bookmarklet = 'javascript:' + encodeURIComponent(result.trim());
console.log(bookmarklet);
