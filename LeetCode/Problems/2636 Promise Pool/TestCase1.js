module.exports = {
    functions: [
        () => new Promise(res => setTimeout(res, 300)),
        () => new Promise(res => setTimeout(res, 400)),
        () => new Promise(res => setTimeout(res, 200))
    ],
    n: 2,
    output: [[300, 400, 500], 500]
};
