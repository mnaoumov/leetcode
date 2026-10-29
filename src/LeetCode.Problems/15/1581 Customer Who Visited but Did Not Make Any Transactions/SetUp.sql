CREATE TABLE Visits
(
    visit_id int,
    customer_id int
);

CREATE TABLE Transactions
(
    transaction_id int,
    visit_id int,
    amount int
);
