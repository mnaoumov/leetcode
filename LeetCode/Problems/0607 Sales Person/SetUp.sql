CREATE TABLE SalesPerson
(
    sales_id int,
    name varchar(255),
    salary int,
    commission_rate int,
    hire_date date
);

CREATE TABLE Company
(
    com_id int,
    name varchar(255),
    city varchar(255)
);

CREATE TABLE Orders
(
    order_id int,
    order_date date,
    com_id int,
    sales_id int,
    amount int
);
