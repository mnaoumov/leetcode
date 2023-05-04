({
    inputFunction: () => {
        const obj = new Date();
        const classFunction = Date;
        return checkIfInstanceOf(obj, classFunction);
    },
    output: true
})
