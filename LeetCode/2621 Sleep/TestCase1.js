({
    inputFunction: async () => {
        const millis = 100;
        const t = Date.now();
        await sleep(millis);
        return Date.now() - t;
    },
    output: 100
})
