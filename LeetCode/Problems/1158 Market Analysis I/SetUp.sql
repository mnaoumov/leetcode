CREATE TABLE Users
(
    user_id int,
    join_date date,
    favorite_brand varchar(10)
);

CREATE TABLE Orders
(
    order_id int,
    order_date date,
    item_id int,
    buyer_id int,
    seller_id int
);

CREATE TABLE Items
(
    item_id int,
    item_brand varchar(10)
);
