({
    inputFunction: () => {
        const n = -2;
        const m = 5;
        const counter = createCounter(n);
        return Array.from(Array(m)).map(_ => counter());
    },
    output: [-2,-1,0,1,2]
})
