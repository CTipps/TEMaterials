USE master;
GO

DROP DATABASE IF EXISTS GalleryDB;
GO

CREATE DATABASE GalleryDB;
GO

USE GalleryDB;

CREATE TABLE Customer (
Customer_Id int identity PRIMARY KEY,
First_Name nvarchar(30) NOT NULL,
Last_Name nvarchar(30) NOT NULL,
Phone nvarchar(30),
Address nvarchar(30),
Customer_Account nvarchar(30) NOT NULL,
)
GO


CREATE TABLE Artist (
Artist_Id int identity PRIMARY KEY,
First_Name nvarchar(30),
Last_Name nvarchar(30)
)
GO

CREATE TABLE Painting (
Painting_Id int identity PRIMARY KEY,
Title nvarchar(30) NOT NULL,
Artist_Id int NOT NULL,
FOREIGN KEY (Artist_Id) References Artist(Artist_Id)

)
GO

CREATE TABLE Purchase (
Order_Id int identity (10000, 1) PRIMARY KEY,
Painting_Id int NOT NULL,
Purchase_Date nvarchar(30) NOT NULL,
Customer_Id int Not Null,
Sales_Price decimal NOT NULL,
FOREIGN KEY (Painting_Id) References Painting(Painting_Id),
FOREIGN KEY (Customer_Id) REFERENCES Customer(Customer_Id)
)
GO

INSERT INTO Customer (First_Name, Last_Name, Phone, Address, Customer_Account)
VALUES ('Elizabeth', 'Jackson', '2062846783', '123 4th Street', 'L3J 4S4')

INSERT INTO Artist (First_Name, Last_Name)
VALUES ('Carol', 'Channing'), ('Dennis', 'Frings')

INSERT INTO Painting (Title, Artist_Id)
VALUES ('Laugh With Teeth', (SELECT Artist_Id FROM Artist WHERE First_Name = 'Carol')), 
('At the Movies', (SELECT Artist_Id FROM Artist WHERE First_Name = 'Carol')),
('South toward Emerald Sea', (SELECT Artist_Id FROM Artist WHERE First_Name = 'Dennis'))

INSERT INTO Purchase (Painting_Id, Purchase_Date, Customer_Id, Sales_Price)
VALUES ((SELECT Painting_Id FROM Painting WHERE title = 'Laugh With Teeth'), '09/17/2000', (SELECT Customer_Id From Customer Where First_Name = 'Elizabeth'), 7000.00),
((SELECT Painting_Id FROM Painting WHERE title = 'South toward Emerald Sea'), '05/11/2000', (SELECT Customer_Id From Customer Where First_Name = 'Elizabeth'), 1800.00),
((SELECT Painting_Id FROM Painting WHERE title = 'At The Movies'), '02/14/2002', (SELECT Customer_Id From Customer Where First_Name = 'Elizabeth'), 5550.00),
((SELECT Painting_Id FROM Painting WHERE title = 'South toward Emerald Sea'), '07/15/2003', (SELECT Customer_Id From Customer Where First_Name = 'Elizabeth'), 2200.00)

