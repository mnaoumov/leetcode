const fakeTimers = require("@sinonjs/fake-timers");

// One Node process runs many tests, so each test loads its scripts afresh rather than getting the last test's modules.
const requireFresh = (path) => {
    delete require.cache[require.resolve(path)];
    return require(path);
};

// Plain JSON cannot tell undefined, NaN, Infinity, a BigInt, a Map or a Set from other values, so each becomes an object
// tagged with "$type". A real object's keys starting with "$" get one more "$", so no real value reads as a tag.
const normalize = (value, ancestors = []) => {
    if (value === undefined) {
        return { $type: "undefined" };
    }

    if (typeof value === "number") {
        return Number.isFinite(value) ? value : { $type: "number", value: String(value) };
    }

    if (typeof value === "bigint") {
        return { $type: "bigint", value: value.toString() };
    }

    // Dropped, as JSON.stringify drops them.
    if (typeof value === "function" || typeof value === "symbol") {
        return undefined;
    }

    if (value === null || typeof value !== "object") {
        return value;
    }

    if (typeof value.toJSON === "function") {
        return normalize(value.toJSON(), ancestors);
    }

    if (ancestors.includes(value)) {
        throw new TypeError("Converting circular structure to JSON");
    }

    const inner = [...ancestors, value];

    if (Array.isArray(value)) {
        return value.map(item => normalize(item, inner) ?? null);
    }

    if (value instanceof Map) {
        return { $type: "Map", entries: [...value].map(([key, item]) => [normalize(key, inner) ?? null, normalize(item, inner) ?? null]) };
    }

    if (value instanceof Set) {
        return { $type: "Set", values: [...value].map(item => normalize(item, inner) ?? null) };
    }

    if (value instanceof Error) {
        value = {
            ...value,
            name: value.name,
            message: value.message,
            stack: value.stack
        };
    }

    const result = {};
    for (const key of Object.keys(value).sort()) {
        const item = normalize(value[key], inner);
        if (item !== undefined) {
            result[key.startsWith("$") ? `$${key}` : key] = item;
        }
    }

    return result;
};

const toJson = (obj) => JSON.stringify(normalize(obj));

module.exports = async (solutionFilePath, testCaseFilePath, testsFilePath, debug) => {
    let actualResult = null;
    let output = null;
    const errors = [];
    const onUnhandledRejection = e2 => errors.push(e2);
    const clock = fakeTimers.install();

    try {
        // ReSharper disable once UseOfImplicitGlobalInFunctionScope
        process.on("unhandledRejection", onUnhandledRejection);

        const testCase = requireFresh(testCaseFilePath);
        // ReSharper disable once PossiblyUnassignedProperty
        output = testCase.output;

        const solution = requireFresh(solutionFilePath);
        const test = requireFresh(testsFilePath);

        const actualResultPromise = (async () => {
            if (debug) {
                debugger;
            }

            return await test(solution, testCase);
        })();
        await clock.runAllAsync();
        actualResult = await actualResultPromise;
    } catch (e) {
        errors.push(e);
    } finally {
        // ReSharper disable once UseOfImplicitGlobalInFunctionScope
        process.off("unhandledRejection", onUnhandledRejection);
        clock.uninstall();
    }

    if (errors.length > 0) {
        actualResult = errors;
    }

    const actualResultJson = toJson(actualResult);
    const expectedResultJson = toJson(output);

    return {
        actualResultJson,
        expectedResultJson
    };
};

// For the framework's own tests.
module.exports.toJson = toJson;

// A test case module may export timeoutInMilliseconds; null when it does not. Async, as Jering hands a plain function a
// callback first.
module.exports.getTimeoutInMilliseconds = async (testCaseFilePath) =>
    requireFresh(testCaseFilePath).timeoutInMilliseconds ?? null;
