// https://leetcode.com/submissions/detail/957367765/

/**
 * @param {Generator} generator
 * @return {[Function, Promise]}
 */
var cancellable = function(generator) {
    let isCancelled = false;
    // ReSharper disable once AssignedValueIsNeverUsed
    const cancel = () => isCancelled = true;
    const promise = (async () => {
        let done;
        let value = null;
        while (true) {
            try {
                const argument = await value;

                if (isCancelled) {
                    throw "Cancelled";
                }

                ({ done, value } = generator.next(argument));
            } catch (e) {
                ({ done, value } = generator.throw(e));
            }

            if (done) {
                return value;
            }
        }
    })();

    return [cancel, promise];
};

module.exports = cancellable;
