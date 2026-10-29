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
    product_id int
);

CREATE TABLE Products
(
    product_id int,
    product_name varchar(20),
    price int
);
