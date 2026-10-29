CREATE TABLE Sales
(
    sale_date date,
    fruit varchar(7) CHECK(fruit IN ('apples', 'oranges')),
    sold_num int
);
