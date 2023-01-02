Create table If Not Exists Person (person_id int, name varchar(30), profession ENUM('Doctor','Singer','Actor','Player','Engineer','Lawyer'))

Truncate table Person

insert into Person (person_id, name, profession) values ('1', 'Alex', 'Singer')

insert into Person (person_id, name, profession) values ('3', 'Alice', 'Actor')

insert into Person (person_id, name, profession) values ('2', 'Bob', 'Player')

insert into Person (person_id, name, profession) values ('4', 'Messi', 'Doctor')

insert into Person (person_id, name, profession) values ('6', 'Tyson', 'Engineer')

insert into Person (person_id, name, profession) values ('5', 'Meir', 'Lawyer')