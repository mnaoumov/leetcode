const sutTest = async (classFunc, testCase) => {
    const ans = [];
    const promises = [];

    let sut;

    for (let i = 0; i < testCase.commands.length; i++) {
        const command = testCase.commands[i];
        const parameters = testCase.parameters[i];
        const time = testCase.times[i];

        const promise = new Promise((resolve) => {
            setTimeout(() => {
                try {
                    if (command === classFunc.name) {
                        sut = new (classFunc.bind.apply(classFunc, parameters));
                        ans.push(null);
                    } else {
                        const result = sut[command].apply(sut, parameters);
                        ans.push(result);
                    }
                }
                catch (e) {
                    ans.push(e);
                }

                resolve();
            }, time);
        });

        promises.push(promise);
    }

    await Promise.all(promises);
    return ans;
};

module.exports = sutTest;
