({
    inputFunction: async () => {
        const millis = 200;
        const t = Date.now();
        await sleep(millis);
        return Date.now() - t;
    },
    output: 200,
    timeoutInMilliseconds: 300
})
