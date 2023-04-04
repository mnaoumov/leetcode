CREATE TABLE Product
(
    product_id int,
    product_name varchar(10),
    unit_price int
);

CREATE TABLE Sales
(
    seller_id int,
    product_id int,
    buyer_id int,
    sale_date date,
    quantity int,
    price int
);
