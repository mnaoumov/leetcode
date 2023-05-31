module.exports = async (EventEmitter, testCase) => {
    let emitter;
    const subscriptions = [];
    const ans = testCase.actions.map((action, index) => {
        const args = testCase.values[index];
        switch (action) {
            case "EventEmitter": {
                emitter = new EventEmitter();
                return [];
            }
            case "subscribe": {
                // ReSharper disable once PossiblyUnassignedProperty
                subscriptions.push(emitter.subscribe(...args));
                return ["subscribed"];
            }
            case "emit": {
                // ReSharper disable once PossiblyUnassignedProperty
                return ["emitted", emitter.emit(...args)];
            }
            case "unsubscribe": {
                const subscriptionIndex = args[0];
                subscriptions[subscriptionIndex].unsubscribe();
                return ["unsubscribed", subscriptionIndex];
            }
            default: {
                throw `Invalid action ${action}`;
            }
        }
    });
    return ans;
};
