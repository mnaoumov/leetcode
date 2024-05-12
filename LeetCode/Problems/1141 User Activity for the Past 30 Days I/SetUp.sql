CREATE TABLE Activity
(
    user_id int,
    session_id int,
    activity_date date,
    activity_type varchar(12) NOT NULL CHECK(activity_type IN ('open_session', 'end_session', 'scroll_down', 'send_message'))
);
