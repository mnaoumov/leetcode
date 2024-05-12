CREATE TABLE Stocks
(
    stock_name varchar(15),
    operation varchar(4) NOT NULL CHECK (operation IN ('Sell', 'Buy')),
    operation_day int,
    price int
);
