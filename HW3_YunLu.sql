-- HW3: 3/23
-- Editor: Yun Lu
Use Northwind

-- 1.
SELECT e.City
FROM dbo.Employees e
INNER JOIN Customers c ON e.City =c.City

-- 2a. (notes: Subquery can be in SELECT, FROM, WHERE IN)
SELECT City
FROM Customers
WHERE City NOT IN (SELECT City FROM Employees)

-- 2b. (notes: left exclusive join)
SELECT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL

-- 3. 
SELECT p.ProductName, SUM(od.quantity) [Total Order Quantities]
FROM Products p
LEFT JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductName

-- 4.
SELECT c.City, COUNT(od.ProductID) [Total Number of Products]
FROM Customers c 
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
-- WHERE City = 'Aachen' -> for varification
GROUP BY City

/* Varify city = 'Aachen' has 10 records
SELECT c.City, c.CustomerID, o.OrderID
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE City = 'Aachen'
*/

-- 5a.
SELECT c1.City
FROM Customers c1, Customers c2
WHERE c1.City = c2.City AND c1.CustomerID != c2.CustomerID
UNION 
SELECT c2.City
FROM Customers c1, Customers c2
WHERE c1.City = c2.City AND c1.CustomerID != c2.CustomerID

SELECT *
FROM Customers

-- 5b.
SELECT City
FROM Customers
GROUP BY City
HAVING COUNT(CustomerID) > 1

-- 6.
SELECT c.City
FROM Customers c, Orders o, [Order Details] od
WHERE c.CustomerID = o.CustomerID AND o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(c.City) > 1

-- 7.
SELECT DISTINCT o.CustomerID --, o.ShipCity, c.City
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE o.ShipCity != c.City

-- 8.
SELECT TOP 5 ProductID, AVG(UnitPrice) [Average Price],
(SELECT TOP 1 c.City FROM Customers c, [Order Details] od, Orders o 
WHERE od.OrderID = o.OrderID AND o.CustomerID = c.CustomerID 
ORDER BY COUNT(Quantity) OVER(PARTITION BY City) DESC)
FROM [Order Details]
GROUP BY ProductID
ORDER BY SUM(Quantity) DESC

/* This solution contains duplicate
SELECT od.ProductID, 
AVG(UnitPrice) OVER(PARTITION BY ProductID) [Average Price],
c.City
FROM [Order Details] od, Orders o, Customers c
WHERE od.OrderID = o.OrderID AND o.CustomerID = c.CustomerID
ORDER BY SUM(Quantity) OVER(PARTITION BY ProductID) DESC, COUNT(Quantity) OVER(PARTITION BY City) DESC
*/

-- 9a.
SELECT City
FROM Employees 
WHERE City NOT IN (SELECT ShipCity FROM Orders)

-- 9b. 
SELECT City
FROM Employees
EXCEPT
SELECT ShipCity
FROM Orders

-- 10.
SELECT c1.ShipCity
FROM 
(SELECT TOP 1 ShipCity
FROM Orders
ORDER BY COUNT(ShipCity) OVER(PARTITION BY ShipCity) DESC) c1
JOIN 
(SELECT TOP 1 o.ShipCity
FROM Orders o, [Order Details] od
WHERE o.OrderID = od.OrderID
ORDER BY SUM(od.Quantity) OVER(PARTITION BY od.ProductID) DESC) c2
ON c1.ShipCity = c2.ShipCity

-- 11.
/*
One technique is by using CTE to identify the duplicates record with ROW_NUMBER function.
In this way, we are able to get a ranking number that represnts the duplicate counter.
After the CTE being established, we then delete the records from CTE that have the ranking number larder than 1.
*/
-- For example:
CREATE TABLE Contact(  
    id INT,
    name VARCHAR(30)
)
INSERT Contact values(1, 'Jermy'), (1, 'Jermy'), (4, 'Lucy'), (4, 'Lucy'), (4, 'Lucy')

-- Contain duplicates
SELECT * FROM Contact

GO
WITH dupCTE (id, name, [Duplicate Count]) 
AS (
    SELECT id, name, 
    ROW_NUMBER() OVER(PARTITION BY id, name ORDER BY id) [Duplicate Count]
FROM Contact)
DELETE FROM dupCTE
WHERE [Duplicate Count] > 1
GO

-- Without duplicates
SELECT * FROM Contact