const { execSync } = require('node:child_process');
const path = require('node:path');

const result = execSync(`npx esbuild ${path.join(__dirname, 'bookmarklet.ts')} --bundle --format=iife --minify --target=es2020`, {
    encoding: 'utf8'
});

const bookmarklet = 'javascript:' + encodeURIComponent(result.trim());
console.log(bookmarklet);
