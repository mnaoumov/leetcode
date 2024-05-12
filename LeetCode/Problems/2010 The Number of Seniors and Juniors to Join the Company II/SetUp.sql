CREATE TABLE Candidates
(
    employee_id int,
    experience varchar(6) CHECK(experience IN ('Senior', 'Junior')),
    salary int
);
