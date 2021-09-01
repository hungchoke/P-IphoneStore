CREATE DATABASE IF NOT EXISTS iphonestore;

USE iphonestore;

DROP TABLE iphones;
CREATE TABLE iphones(
	iphone_id INT PRIMARY KEY,
    iphone_name CHAR(50),
    iphone_process CHAR(50),
    iphone_memory CHAR(50),
    iphone_color CHAR(50),
    iphone_storage CHAR(50),
    iphone_camera CHAR(100),
    iphone_battery CHAR(50),
    iphone_screen CHAR(100),
    iphone_network CHAR(100),
    iphone_wireless CHAR(100),
    iphone_waterproof CHAR(100),
    iphone_support CHAR(100),
    iphone_price DOUBLE
)
SELECT * FROM iphones;

DROP TABLE staffs;
CREATE TABLE staffs(
	staff_id INT PRIMARY KEY,
    staff_name CHAR(50),
    staff_email CHAR(100),
    staff_phone INT NOT NULL,
    staff_username CHAR(100),
    staff_password CHAR(100),
    staff_role CHAR(20)
)
SELECT * FROM staffs;

DROP TABLE customers;
CREATE TABLE customers(
	customer_id INT PRIMARY KEY,
    customer_name CHAR(50),
    customer_address CHAR(200),
    customer_email CHAR(100),
    customer_phone CHAR(50)
)
SELECT * FROM customers;


DROP TABLE invoices;
CREATE TABLE invoices(
	invoice_no INT PRIMARY KEY,
    invoice_data DATETIME,
    invoice_status CHAR(100),
    customer_id INT NOT NULL,
    staff_id INT NOT NULL,
    FOREIGN KEY (customer_id) REFERENCES customers(customer_id),
    FOREIGN KEY (staff_id) REFERENCES staffs(staff_id)
)
SELECT * FROM invoices;

DROP TABLE invoicedetails;
CREATE TABLE invoicedetails(
	invoice_no INT NOT NULL,
    iphone_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DOUBLE,
    FOREIGN KEY (invoice_no) REFERENCES invoices(invoice_no),
    FOREIGN KEY (iphone_id) REFERENCES iphones(iphone_id)
)
SELECT * FROM invoicedetails;

DROP TABLE colors;
CREATE TABLE colors(
    color_id INT PRIMARY KEY,
    color_name CHAR(50),
    color_quantity INT NOT NULL,
    iphone_id INT NOT NULL,
    FOREIGN KEY (iphone_id) REFERENCES iphones(iphone_id)
)
SELECT * FROM colors;

