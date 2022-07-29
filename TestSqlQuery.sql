-- Удаление и создание таблиц  Customers и Orders
IF OBJECT_ID ('dbo.Orders') IS NOT NULL  
	DROP TABLE Orders;  
GO 
IF OBJECT_ID ('dbo.Customers') IS NOT NULL  
	DROP TABLE Customers;  
GO  

CREATE TABLE Customers  
(  
	Id INT PRIMARY KEY IDENTITY(1,1),  
	Name VARCHAR(20) not null,
);

CREATE TABLE Orders
(
    Id INT PRIMARY KEY IDENTITY(1,1),
	CustomerId INT,
    FOREIGN KEY (CustomerId) REFERENCES dbo.Customers(Id) ON DELETE CASCADE,
)

--Заполнение данными
INSERT Customers (Name) VALUES ('Max');  
INSERT Customers (Name) VALUES ('Pavel');
INSERT Customers (Name) VALUES ('Ivan');
INSERT Customers (Name) VALUES ('Leonid');  

INSERT Orders(CustomerId) VALUES (2);
INSERT Orders(CustomerId) VALUES (4); 

-- запрос на выборку
SELECT c.Name FROM Customers AS c
JOIN Orders ON c.Id = Orders. CustomerId
