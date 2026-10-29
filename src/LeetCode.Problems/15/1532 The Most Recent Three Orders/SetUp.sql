CREATE TABLE Customers
(
    customer_id int,
    name varchar(10)
);

CREATE TABLE Orders
(
    order_id int,
    order_date date,
    customer_id int,
    cost int
);
