module.exports = async (solution, testCase) => {
    const createHelloWorld = solution;
    const f = createHelloWorld();
    return f.apply(null, testCase.args)
};
