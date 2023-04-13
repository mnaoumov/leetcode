// SkipSolution: WrongAnswer
// https://leetcode.com/submissions/detail/932780384/

var checkIfInstanceOf = function (obj, classFunction) {
    while (obj !== null) {
        obj = Object.getPrototypeOf(obj);
        if (obj === classFunction.prototype) {
            return true;
        }
    }

    return false;
};
