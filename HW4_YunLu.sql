-- HW4: 3/24
-- Editor: Yun Lu
Use Northwind

-- 1. 
GO
CREATE VIEW view_product_order_lu AS (
    SELECT p.ProductName, SUM(od.Quantity) [Total Order Quantity]
    FROM Products p, [Order Details] od
    WHERE p.ProductID = od.ProductID
    GROUP BY p.ProductName
)
GO
SELECT * FROM dbo.view_product_order_lu

-- 2.
GO
CREATE PROC sp_product_order_quantity_lu
@prodID INT,
@totalQuan INT OUT
AS
BEGIN
    SELECT @totalQuan = SUM(od.Quantity)
    FROM Products p, [Order Details] od
    WHERE p.ProductID = od.ProductID AND p.ProductID = @prodID
    GROUP BY p.ProductID
END
GO

DECLARE @quantity INT
EXEC sp_product_order_quantity_lu 1, @quantity OUT
SELECT @quantity [Product Total Quantity]

-- 3. 
GO
CREATE PROC sp_product_order_city_lu
@prodName VARCHAR(40),
@city VARCHAR(15) OUT,
@cityTotalOrders INT OUT
AS
BEGIN
    WITH topFiveCity_CTE(ShipCity, Quantity)
    AS (
        SELECT TOP 5 o.ShipCity, SUM(od.Quantity)
        FROM [Order Details] od, orders o, Products p
        WHERE od.OrderID = o.OrderID AND od.ProductID = p.ProductID AND p.ProductName = @prodName
        GROUP BY o.ShipCity
        ORDER BY SUM(od.Quantity) DESC
    )
    SELECT *
    FROM topFiveCity_CTE
END
GO

DECLARE @cityName VARCHAR(15), @totalOrderNums INT
EXEC sp_product_order_city_lu 'Chai', @cityName OUT, @totalOrderNums OUT

-- 4.
CREATE TABLE city_lu (
    Id INT PRIMARY KEY,
    City VARCHAR(30)
)
CREATE TABLE people_lu (
    Id INT PRIMARY KEY,
    Name VARCHAR(30),
    CityId INT FOREIGN KEY REFERENCES city_lu(Id)
)
INSERT INTO city_lu VALUES (1, 'Seattle'), (2, 'Green Bay')
INSERT INTO people_lu VALUES (1, 'Aaron Rodger', 2), (2, 'Russell Vilson', 1), (3, 'Jody Nelson', 2)
-- If we delete 'Seattle' from city_lu without inserting a new city 'Madison that in near future will replace 'Seatle', 
-- then error occures and deletion fails. 
INSERT INTO city_lu VALUES (3, 'Madison')
UPDATE people_lu SET CityId = 3 WHERE CityId = 1
DELETE FROM city_lu WHERE city = 'Seattle'

GO
CREATE VIEW Packers_lu AS (
    SELECT p.*
    FROM people_lu p, city_lu c
    WHERE p.CityId = c.Id AND c.City = 'Green Bay'
)
GO
SELECT * FROM dbo.Packers_lu

DROP VIEW Packers_lu -- when referencing tables were deleted, view won't work.
DROP TABLE people_lu, city_lu

-- 5. Not working, in question
GO
CREATE PROC sp_birthday_employees_lu
AS
BEGIN
    DECLARE @createString NVARCHAR(MAX)
    DECLARE @insertString NVARCHAR(MAX)
    SET @createString = 'CREATE TABLE birthday_employees_lu(EmployeeID INT)'
    SET @insertString = 'INSERT INTO birthday_employees_lu(EmployeeID)
        SELECT EmployeeID
        FROM Employees
        WHERE Month(BirthDate) = 2'

    EXEC @createString
    EXEC @insertString
END

EXEC sp_birthday_employees_lu
GO

DROP TABLE birthday_employees_lu
SELECT * FROM Employees

-- 6.
/* First of all, two identical tables should have the same number of rows and the same attributes.
   We can select the entire table to compare the rowcount. Two rowcont values aren't the same means two tables have different data.

   As for verifying if data values whether are identical, we can use EXCEPT statement in between table selection.
   If the query returns empty result set, the two tables are identical and vice versa.
*/

