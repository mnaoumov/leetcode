function sum(a, b) {
    return a + b;
}

function fib(n) {
    if (n <= 1) {
        return 1;
    }

    return fib(n - 1) + fib(n - 2);
}

function factorial(n) {
    if (n <= 1) {
        return 1;
    }

    return factorial(n - 1) * n;
}

const funcs = {
    sum,
    fib,
    factorial
};

module.exports = async (memoize, testCase) => {
    const func = funcs[testCase.funcName];

    let callCount = 0;
    const memoizedFunc = memoize((...args) => {
        callCount++;
        // ReSharper disable once PossiblyUnassignedProperty
        return func.apply(null, args);
    });

    const ans = [];

    for (let i = 0; i < testCase.commands.length; i++) {
        const command = testCase.commands[i];

        switch (command) {
            case "call":
                // ReSharper disable once PossiblyUnassignedProperty
                ans.push(memoizedFunc.apply(null, testCase.parameters[i]));
                break;
            case "getCallCount":
                ans.push(callCount);
                break;
            default:
                throw new Error(`Unknown command ${command}`);
        }
    }

    return ans;
};
