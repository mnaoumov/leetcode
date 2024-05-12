CREATE TABLE Product
(
    product_id int,
    product_name varchar(30)
);

CREATE TABLE Sales
(
    product_id int,
    period_start date,
    period_end date,
    average_daily_sales int
);
