({
    inputFunction: () => {
        class Animal { }
        class Dog extends Animal { }
        return checkIfInstanceOf(new Dog(), Animal);
    },
    output: true
})
