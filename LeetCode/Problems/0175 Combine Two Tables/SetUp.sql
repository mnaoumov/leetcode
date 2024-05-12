CREATE TABLE Person
(
    personId int,
    firstName varchar(255),
    lastName varchar(255)
);

CREATE TABLE Address
(
    addressId int,
    personId int,
    city varchar(255),
    state varchar(255)
);