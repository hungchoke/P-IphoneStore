create database if not exists LoginDB;

use LoginDB;

create table Staffs(
	staff_id int auto_increment primary key,
    staff_name varchar(100) not null,
    user_name varchar(100) not null unique,
    user_pass varchar(100) not null,
    telephone varchar(100),
    email varchar(100) unique,
    role int not null default 1
);

create user if not exists 'iphonestaff'@'localhost' identified by 'iphonestore';
grant all on LoginDB.* to 'iphonestaff'@'localhost';

insert into Staffs(staff_name, user_name, user_pass, role) values
	('Sale','sale','a288c42085685d673b9450d539e06695',1);
select * from Staffs;
select * from Staffs where user_name= 'sale' and user_pass ='085685d673b9450d539e06695';