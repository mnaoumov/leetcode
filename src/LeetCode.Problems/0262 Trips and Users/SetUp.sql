CREATE TABLE Trips
(
    id int,
    client_id int,
    driver_id int,
    city_id int,
    status varchar(19) CHECK (status IN ('completed', 'cancelled_by_driver', 'cancelled_by_client')),
    request_at varchar(50)
);

CREATE TABLE Users
(
    users_id int,
    banned varchar(3) CHECK (banned IN ('Yes', 'No')),
    role varchar(7) CHECK (role IN ('client', 'driver', 'partner'))
);
