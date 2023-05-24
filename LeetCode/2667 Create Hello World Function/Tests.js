module.exports = async (createHelloWorld, testCase) => {
    /**
     * @type {function}
     */
    const f = createHelloWorld();
    return f.apply(null, testCase.args);
};
