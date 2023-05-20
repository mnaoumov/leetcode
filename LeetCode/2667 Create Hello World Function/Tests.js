module.exports = async (solution, testCase) => {
    const createHelloWorld = solution;
    /**
     * @type {function}
     */
    const f = createHelloWorld();
    return f.apply(null, testCase.args);
};
