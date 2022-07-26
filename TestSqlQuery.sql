-- Удаление и создание таблиц  Customers и Orders
IF OBJECT_ID ('dbo.Customers') IS NOT NULL  
	DROP TABLE Customers;  
GO  
CREATE TABLE Customers  
(  
	Id int IDENTITY(1,1),  
	Name varchar (20),  
);

IF OBJECT_ID ('dbo.Orders') IS NOT NULL  
	DROP TABLE Orders;  
GO  
CREATE TABLE Orders
(
    Id int IDENTITY(1,1),  
    CustomerId INT,
)
--Заполнение данными
INSERT Customers (Name) VALUES ('Max');  
INSERT Customers (Name) VALUES ('Pavel');
INSERT Customers (Name) VALUES ('Ivan');
INSERT Customers (Name) VALUES ('Leonid');  

INSERT Orders(CustomerId) VALUES (2);
INSERT Orders(CustomerId) VALUES (4); 

-- запрос на выборку
select c.Name from Customers as c
join Orders on c.Id = Orders. CustomerId
