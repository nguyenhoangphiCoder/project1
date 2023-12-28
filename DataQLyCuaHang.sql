create database QlyCuaHang
go
use QlyCuaHang
go
-- Create Customers table
CREATE TABLE Customers (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(20),
	Email NVARCHAR(255) UNIQUE,
	Day DATETIME
);
go

-- Create Products table
CREATE TABLE Products (
    Id INT PRIMARY KEY,
    ProductName NVARCHAR(255) NOT NULL,
    MachineType NVARCHAR(255),
    Quantity int,
    Price Decimal(18,2),
    Status NVARCHAR(50),
    Description NVARCHAR(MAX),
	SuplierId Int,
	CONSTRAINT FK_Products_Suplier FOREIGN KEY(SuplierId) REFERENCES Suplier(Id)

);
go

-- Create Staff table
CREATE TABLE Staff (
    Id INT PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    BirthDate DATE,
	PhoneNumber NVARCHAR(20),
	Email NVARCHAR(255) UNIQUE,
    Position NVARCHAr(255),
    Wage Int,
    
    CONSTRAINT UC_PhoneNumber UNIQUE (PhoneNumber)
);
go
-- Create Revenue table
CREATE TABLE Revenue (
    Id INT PRIMARY KEY,
    Date DATE,
    TotalRevenue DECIMAL(18, 2),
    StaffId INT,
    CONSTRAINT FK_Revenue_Staff FOREIGN KEY (StaffId) REFERENCES Staff(Id)
);
go
-- Create Expenditures table
CREATE TABLE Spending (
    Id INT PRIMARY KEY,
    Date DATE,
    TotalSpending DECIMAL(18, 2),
    Describe NVARCHAR(MAX),
    StaffId INT,
    CONSTRAINT FK_Spending_Staff FOREIGN KEY (StaffId) REFERENCES Staff(Id)
);
go
-- Create Suppliers table
CREATE TABLE Suplier (
    Id INT PRIMARY KEY,
    SuplierName NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(255),
    Address NVARCHAR(255),
	ContracDate Date
);
go
-- Create Users table
CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(255),
    Name NVARCHAR(255),
    Role NVARCHAR(50),
    StaffId INT,
    CONSTRAINT FK_Users_Staff FOREIGN KEY (StaffId) REFERENCES Staff(Id)
);
go