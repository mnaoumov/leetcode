CREATE TABLE Person
(
    person_id int,
    name varchar(30),
    profession varchar(10) NOT NULL CHECK (profession IN ('Doctor','Singer','Actor','Player','Engineer','Lawyer'))
)
