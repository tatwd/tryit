-- create database <database_name>
create database test;

-- or by mysqladmin cli
-- $ mysqladmin -u root -p create test

-- drop database <database_name>
drop database test;

-- or by mysqladmin cli
-- $ mysqladmin -u root -p drop test

-- use <database_name>
use test;

-- Create Table
-- create table <condition_expr> <table_name> (<column_name> <column_type>);
create table if not exists test_user (
    `id` int unsigned auto_increment,
    `name` varchar(100) not null,
    `gender` enum('F', 'M'),
    `created_at` datetime default now(),
) engine=InnoDB default charset=utf8;