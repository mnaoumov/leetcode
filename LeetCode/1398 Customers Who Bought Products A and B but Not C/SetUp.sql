CREATE TABLE Customers
(
    customer_id int,
    customer_name varchar(30)
);

CREATE TABLE Orders
(
    order_id int,
    customer_id int,
    product_name varchar(30)
);
