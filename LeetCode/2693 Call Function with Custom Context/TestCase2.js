module.exports = {
    fn: function tax(price, taxRate) {
        return `The cost of the ${this.item} is ${price * taxRate}`;
    },
    args: [{ "item": "burger" }, 10, 1.1],
    output: "The cost of the burger is 11"
};
