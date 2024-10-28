-- Create Database
Drop Database BusManagementSystem;
Go

CREATE DATABASE BusManagementSystem;
GO

USE BusManagementSystem;
GO

-- Create table Role
CREATE TABLE Role (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(100) NOT NULL
);
GO

-- Create table UserType
CREATE TABLE UserType (
    UserTypeID INT PRIMARY KEY IDENTITY(1,1),
    TypeName NVARCHAR(100) NOT NULL,
    Discount DECIMAL(5,2) NOT NULL
);
GO

-- Create table User
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(100) NOT NULL, -- Đã mã hóa
    Name NVARCHAR(100),
    RoleID INT,
    UserTypeID INT,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID),
    FOREIGN KEY (UserTypeID) REFERENCES UserType(UserTypeID)
);
GO

-- Create table Route
CREATE TABLE Route (
    RouteID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
);
GO

-- Create table Bus
CREATE TABLE Bus (
    BusID INT PRIMARY KEY IDENTITY(1,1),
    Model NVARCHAR(100),
	RouteID INT NOT NULL,
    LicensePlate NVARCHAR(50) UNIQUE NOT NULL,
    Seats INT NOT NULL,
    BasePrice DECIMAL(10,2) NOT NULL
	FOREIGN KEY (RouteID) REFERENCES Route(RouteID)
);
GO



-- Create table Station
CREATE TABLE Station (
    StationID INT PRIMARY KEY IDENTITY(1,1),
    Location NVARCHAR(100) NOT NULL
);
GO

-- Create table GoThrough
CREATE TABLE GoThrough (
    RouteID INT,
    StationID INT,
    PRIMARY KEY (RouteID, StationID),
    FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    FOREIGN KEY (StationID) REFERENCES Station(StationID)
);
GO

-- Create table Order
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);
GO

-- Create table Ticket
CREATE TABLE Ticket (
    TicketID INT PRIMARY KEY IDENTITY(1,1),
    RouteID INT,
    OrderID INT,                     -- Khóa ngoại để liên kết với bảng Order
    Date DATETIME NOT NULL,
    FinalPrice DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (RouteID) REFERENCES Route(RouteID),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) -- Thêm mối quan hệ với Order
);
GO


INSERT INTO Role (RoleName) VALUES
('Guest'),
('Member'),
('Staff'),
('Manager'),
('System Administrator');


INSERT INTO UserType (TypeName, Discount) VALUES
('Regular', 0.00),
('Student', 0.10),
('Senior Citizen', 0.15),
('VIP', 0.20);


INSERT INTO [User] (Username, Password, Name, RoleID, UserTypeID) VALUES
('alice123', 'hashed_password1', 'Alice', 2, 1),
('bob_smith', 'hashed_password2', 'Bob', 3, 2),
('charlie_driver', 'hashed_password3', 'Charlie', 4, 3),
('david_control', 'hashed_password4', 'David', 3, 4),
('eve_manager', 'hashed_password5', 'Eve', 5, 1);

INSERT INTO Route (Name) VALUES
('Route 1'),
('Route 2'),
('Route 3');

INSERT INTO Bus (Model, RouteID, LicensePlate, Seats, BasePrice) VALUES
('Bus Model A', 1 , 'ABC-123', 30, 500000.00),
('Bus Model B', 2, 'DEF-456', 40, 600000.00),
('Bus Model C', 3, 'GHI-789', 50, 700000.00);


INSERT INTO Station (Location) VALUES
('Station 1'),
('Station 2'),
('Station 3'),
('Station 4');





INSERT INTO GoThrough (RouteID, StationID) VALUES
(1, 1),
(1, 2),
(2, 2),
(2, 3);


INSERT INTO [Order] (UserID, OrderDate, TotalPrice) VALUES
(1, GETDATE(), 550000.00),
(2, GETDATE(), 650000.00);


INSERT INTO Ticket (RouteID, OrderID, Date, FinalPrice) VALUES
( 1, 1, GETDATE(), 550000.00),  -- Vé thuộc về đơn hàng 1
( 2, 2, GETDATE(), 650000.00);  -- Vé thuộc về đơn hàng 2
