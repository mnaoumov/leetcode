module.exports = async (curry, testCase) => {
    let ans = curry(testCase.fn);
    for (const input of testCase.inputs) {
        ans = ans(...input);
    }
    return ans;
};
