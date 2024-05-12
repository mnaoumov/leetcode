CREATE TABLE Variables
(
    name varchar(3),
    value int
);

CREATE TABLE Expressions
(
    left_operand varchar(3),
    operator char(1) CHECK(operator IN ('>', '<', '=')),
    right_operand varchar(3)
);
