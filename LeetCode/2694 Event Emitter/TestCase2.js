module.exports = {
  "actions": ["EventEmitter","subscribe","emit","emit"],
  "values": [[],["firstEvent",function cb1(...args) { return args.join(','); }],["firstEvent",[1,2,3]],["firstEvent",[3,4,6]]],
  "output": [[],["subscribed"],["emitted",["1,2,3"]],["emitted",["3,4,6"]]]
};
