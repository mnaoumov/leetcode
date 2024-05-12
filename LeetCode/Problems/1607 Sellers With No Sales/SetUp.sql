CREATE TABLE Customer
(
    customer_id int,
    customer_name varchar(20)
);

CREATE TABLE Orders
(
    order_id int,
    sale_date date,
    order_cost int,
    customer_id int,
    seller_id int
);

CREATE TABLE Seller
(
    seller_id int,
    seller_name varchar(20)
);
