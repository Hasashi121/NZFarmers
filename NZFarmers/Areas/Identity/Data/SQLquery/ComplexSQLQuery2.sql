SELECT 
    Category,
    AVG(Price) AS AveragePrice,
    COUNT(*) AS ProductCount
FROM FarmerProducts
GROUP BY Category
HAVING AVG(Price) > 5.00;