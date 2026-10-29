CREATE TABLE Person
(
    id int,
    name varchar(15),
    phone_number varchar(11)
);

CREATE TABLE Country
(
    name varchar(15),
    country_code varchar(3)
);

CREATE TABLE Calls
(
    caller_id int,
    callee_id int,
    duration int
);
