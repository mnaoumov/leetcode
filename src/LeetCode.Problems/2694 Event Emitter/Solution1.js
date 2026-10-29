// https://leetcode.com/submissions/detail/961255532/

// ReSharper disable once InconsistentNaming
class EventEmitter {
    handlersMap = new Map();

    subscribe(event, cb) {
        if (!this.handlersMap.has(event)) {
            this.handlersMap.set(event, new Set());
        }

        // ReSharper disable once PossiblyUnassignedProperty
        this.handlersMap.get(event).add(cb);

        return {
            unsubscribe: () => {
                // ReSharper disable once PossiblyUnassignedProperty
                this.handlersMap.get(event).delete(cb);
            }
        };
    }

    emit(event, args = []) {
        const handlers = Array.from(this.handlersMap.get(event) || []);
        return handlers.map(handler => handler(...args));
    }
}

module.exports = EventEmitter;
