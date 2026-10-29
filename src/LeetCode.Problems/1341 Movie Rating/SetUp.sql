CREATE TABLE Movies
(
    movie_id int,
    title varchar(30)
);

CREATE TABLE Users
(
    user_id int,
    name varchar(30)
);

CREATE TABLE MovieRating
(
    movie_id int,
    user_id int,
    rating int,
    created_at date
);
