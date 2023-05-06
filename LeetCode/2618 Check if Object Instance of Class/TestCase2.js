class Animal { }
class Dog extends Animal { }

module.exports = {
    obj: new Dog(),
    classFunction: Animal,
    output: true
};
