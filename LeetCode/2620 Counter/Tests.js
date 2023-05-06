const testFn = () => {
    const counter = createCounter(n);
    return Array.from(Array(m)).map(_ => counter());
};
