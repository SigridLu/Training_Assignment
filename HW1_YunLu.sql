-- HW1 from Yun Lu
Use AdventureWorks2019

-- 1.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product
-- 2.
SELECT ProductID, NAme, Color, ListPrice
FROM Production.Product
WHERE ListPrice != 0
-- 3.
SELECT ProductID, NAme, Color, ListPrice
FROM Production.Product
WHERE Color IS NULL
-- 4.
SELECT ProductID, NAme, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL
-- 5.
SELECT ProductID, NAme, Color, ListPrice
FROM Production.Product
WHERE Color IS NOT NULL 
AND ListPrice > 0
-- 6.
SELECT Name + Color
FROM Production.Product
WHERE Color IS NOT NULL
-- 7.
SELECT 'NAME: ' + Name + ' -- COLOR: ' + Color [Name And Color]
FROM Production.Product
WHERE Color IS NOT NULL
-- 8.
SELECT ProductID, Name
FROM Production.Product
WHERE ProductID BETWEEN 400 AND 500
-- 9.
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color = 'Black' OR Color = 'Blue'
-- 10.
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Name LIKE 'S%'
-- 11.
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE 'S%'
ORDER BY Name
-- 12.
SELECT Name, ListPrice
FROM Production.Product
WHERE Name LIKE '[A,S]%'
ORDER BY Name
-- 13. 
SELECT Name
FROM Production.Product
WHERE Name LIKE 'SPO%' AND NAME NOT LIKE 'SPOK%'
ORDER BY Name
-- 14. 
SELECT DISTINCT Color
FROM Production.Product
ORDER BY Color DESC
-- 15.
SELECT DISTINCT ProductSubcategoryID, Color
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL AND
Color IS NOT NULL
