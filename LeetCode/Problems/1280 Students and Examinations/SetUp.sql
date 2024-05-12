CREATE TABLE Students
(
    student_id int,
    student_name varchar(20)
);

CREATE TABLE Subjects
(
    subject_name varchar(20)
);

CREATE TABLE Examinations
(
    student_id int,
    subject_name varchar(20)
);
