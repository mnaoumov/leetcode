// https://leetcode.com/submissions/detail/945748120/

// ReSharper disable once InconsistentNaming
class Counter {
    constructor(init) {
        this.init = init;
        this.value = init;
    }

    increment() {
        this.value++;
        return this.value;
    }

    decrement() {
        this.value--;
        return this.value;
    }

    reset() {
        this.value = this.init;
        return this.value;
    }
}

/**
 * @param {integer} init
 * @return { increment: Function, decrement: Function, reset: Function }
 */
var createCounter = function(init) {
    return new Counter(init);
};

module.exports = createCounter;
