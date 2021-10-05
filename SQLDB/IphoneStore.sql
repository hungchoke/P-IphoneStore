DROP DATABASE IF EXISTS iphonestore;

CREATE DATABASE IF NOT EXISTS iphonestore;

USE iphonestore;

CREATE TABLE colors(
    color_id INT PRIMARY KEY AUTO_INCREMENT,
    color_name CHAR(50),
    color_quantity INT NOT NULL
    
);
create table Staffs(
	staff_id int auto_increment primary key,
    staff_name varchar(100) not null,
    user_name varchar(100) not null unique,
    user_pass varchar(100) not null,
    telephone varchar(100),
    email varchar(100) unique,
    role int not null default 1
);
CREATE TABLE iphones(
	iphone_id int auto_increment primary key,
    iphone_name CHAR(100),
    iphone_process CHAR(100),
    iphone_memory CHAR(100),
    color_id INT NOT NULL,
    iphone_storage CHAR(100),
    iphone_camera CHAR(100),
    iphone_battery CHAR(100),
    iphone_screen CHAR(100),
    iphone_wireless_network CHAR(100),
    iphone_waterproof CHAR(100),
    iphone_support CHAR(100),
    iphone_price DOUBLE,
    FOREIGN KEY (color_id) REFERENCES colors(color_id)
);
SELECT * FROM iphones;


CREATE TABLE customers(
	customer_id INT PRIMARY KEY AUTO_INCREMENT,
    customer_name CHAR(50),
    customer_address CHAR(200),
    customer_email CHAR(100),
    customer_phone CHAR(50)
);
SELECT * FROM customers;


CREATE TABLE invoices(
	invoice_no INT PRIMARY KEY AUTO_INCREMENT,
    invoice_data DATETIME,
    invoice_status CHAR(100),
    customer_id INT NOT NULL,
    staff_id INT NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (staff_id) REFERENCES Staffs(staff_id)
);
SELECT * FROM invoices;

CREATE TABLE invoicedetails(
	invoice_no INT NOT NULL,
    iphone_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DOUBLE,
    FOREIGN KEY (invoice_no) REFERENCES invoices(invoice_no),
    FOREIGN KEY (iphone_id) REFERENCES iphones(iphone_id)
);
SELECT * FROM invoicedetails;


SELECT * FROM colors;




create user if not exists 'iphonestaff'@'localhost' identified by 'iphonestore';
grant all on iphonestore.* to 'iphonestaff'@'localhost';

insert into Staffs(staff_name, user_name, user_pass, role) values
	('Sale','sale','a288c42085685d673b9450d539e06695',1);
insert into Staffs(staff_name, user_name, user_pass, role) values
	('Accountant','accountant','dcb7cfc8aa5d2c0774f4ddb1abba7362',2);
select * from Staffs;
select * from Staffs where user_name= 'sale' and user_pass ='a288c42085685d673b9450d539e06695';
select * from Staffs where user_name= 'accountant' and user_pass ='dcb7cfc8aa5d2c0774f4ddb1abba7362';

delimiter $$
create procedure sp_createCustomer(IN customerName varchar(100), IN customerAddress varchar(200),In customerEmail varchar(100),In customerPhone varchar(100), OUT customerId int)
begin
    insert into Customers(customer_name, customer_address, customer_email, customer_phone) values (customerName, customerAddress, customerEmail, customerPhone); 
    select max(customer_id) into customerId from Customers;
end $$
delimiter ;

call sp_createCustomer('no name','any where','any email','any number',@cusId);
select @cusId;
