// A minute of timer, which the runner's fake clock runs at once.
module.exports = x => new Promise(resolve => setTimeout(() => resolve(x * 2), 60_000));
