CREATE TABLE Users
(
    account int,
    name varchar(20)
);

CREATE TABLE Transactions
(
    trans_id int,
    account int,
    amount int,
    transacted_on date
);
