module.exports = {
  "actions": ["EventEmitter","subscribe","emit","unsubscribe","emit"],
  "values": [[],["firstEvent",(...args) => args.join(",")],["firstEvent",[1,2,3]],[0],["firstEvent",[4,5,6]]],
  "output": [[],["subscribed"],["emitted",["1,2,3"]],["unsubscribed",0],["emitted",[]]]
};
