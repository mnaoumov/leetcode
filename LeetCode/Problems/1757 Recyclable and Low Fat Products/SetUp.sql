CREATE TABLE Products
(
    product_id int,
    low_fats char(1) NOT NULL CHECK (low_fats IN ('Y','N')),
    recyclable char(1) NOT NULL CHECK (recyclable IN ('Y','N'))
);
