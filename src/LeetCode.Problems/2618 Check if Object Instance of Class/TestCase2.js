// ReSharper disable once InconsistentNaming
class Animal { }
// ReSharper disable once InconsistentNaming
class Dog extends Animal { }

module.exports = {
    obj: new Dog(),
    classFunction: Animal,
    output: true
};
