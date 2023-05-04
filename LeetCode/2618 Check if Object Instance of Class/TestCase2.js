({
    inputFunction: () => {
        class Animal { }
        class Dog extends Animal { }

        const obj = new Dog();
        const classFunction = Animal;
        return checkIfInstanceOf(obj, classFunction);
    },
    output: true
})
