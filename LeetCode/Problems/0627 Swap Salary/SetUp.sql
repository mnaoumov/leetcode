CREATE TABLE Salary
(
    id int,
    name varchar(100),
    sex char(1) NOT NULL CHECK(sex IN ('m','f')),
    salary int
);
