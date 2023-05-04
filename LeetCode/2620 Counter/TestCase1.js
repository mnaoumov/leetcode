({
    inputFunction: () => {
        const n = 10;
        const m = 3;
        const counter = createCounter(n);
        return Array.from(Array(m)).map(_ => counter());
    },
    output: [10,11,12]
})
