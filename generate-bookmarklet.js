const fs = require('fs');
const path = require('path');

const src = fs.readFileSync(path.join(__dirname, 'bookmarklet.js'), 'utf8');
const min = src.split('\n').map(l => l.trim()).filter(l => l).join(' ');
const bookmarklet = 'javascript:' + encodeURIComponent(min);

console.log(bookmarklet);
