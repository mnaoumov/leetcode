CREATE TABLE Users
(
    id int,
    name varchar(30)
);

CREATE TABLE Rides
(
    id int,
    user_id int,
    distance int
);
