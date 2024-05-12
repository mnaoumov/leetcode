module.exports = {
    t: 150,
    calls: [
      {"t": 50, inputs: [1, 2]},
      {"t": 300, inputs: [3, 4]},
      {"t": 300, inputs: [5, 6]}
    ],
    output: [{"t": 200, inputs: [1,2]}, {"t": 450, inputs: [5, 6]}]
};
