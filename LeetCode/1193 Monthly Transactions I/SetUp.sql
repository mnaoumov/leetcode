CREATE TABLE Transactions
(
    id int,
    country varchar(4),
    state varchar(8) CHECK (state IN ('approved', 'declined')),
    amount int,
    trans_date date
);
