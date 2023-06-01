module.exports = async (ArrayWrapper, testCase) => {
    switch (testCase.operation) {
        case "Add": {
            const obj1 = new ArrayWrapper(testCase.nums[0]);
            const obj2 = new ArrayWrapper(testCase.nums[1]);
            return obj1 + obj2;
        }

        case "String": {
            const obj = new ArrayWrapper(testCase.nums[0]);
            return String(obj);
        }

        default: {
            throw `Unknown operation ${testCase.operation}`;
        }
    }
};
