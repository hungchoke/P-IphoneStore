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
insert into Staffs(staff_name, user_name, user_pass, role) values
	('Accountant','accountant','dcb7cfc8aa5d2c0774f4ddb1abba7362',2);
select * from Staffs;
select * from Staffs where user_name= 'sale' and user_pass ='a288c42085685d673b9450d539e06695';
select * from Staffs where user_name= 'accountant' and user_pass ='dcb7cfc8aa5d2c0774f4ddb1abba7362';
