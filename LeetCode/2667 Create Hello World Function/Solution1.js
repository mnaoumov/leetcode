// https://leetcode.com/submissions/detail/944639030/

/**
 * @return {Function}
 */
var createHelloWorld = function () {
    return function (...args) {
        return "Hello World";
    }
};

module.exports = createHelloWorld;
