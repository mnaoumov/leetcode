module.exports = async (fibGenerator, testCase) => {
    const gen = fibGenerator();
    const ans = [];
    for (let i = 0; i < testCase.callCount; i++) {
        // ReSharper disable PossiblyUnassignedProperty
        ans.push(gen.next().value);
        // ReSharper restore PossiblyUnassignedProperty
    }
    return ans;
};
