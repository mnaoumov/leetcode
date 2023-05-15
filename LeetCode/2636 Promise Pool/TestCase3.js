module.exports = {
    functions: [
        () => new Promise(res => setTimeout(res, 300)),
        () => new Promise(res => setTimeout(res, 400)),
        () => new Promise(res => setTimeout(res, 200))
    ],
    n: 1,
    output: [[300, 700, 900], 900]
};
