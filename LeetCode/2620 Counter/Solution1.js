// https://leetcode.com/submissions/detail/943601776/

var createCounter = function(n) {
    let value = n;

    return function() {
        const previousValue = value;
        value++;
        return previousValue;
    };
};
