SELECT 
    f.Region,
    COUNT(DISTINCT f.FarmerID) as FarmerCount,
    COUNT(fp.FarmerProductID) as TotalProducts,
    MIN(fp.Price) as LowestPrice,
    MAX(fp.Price) as HighestPrice,
    AVG(fp.Price) as AvgPrice,
    SUM(fp.Stock) as TotalStock
FROM Farmers f
LEFT JOIN FarmerProducts fp ON f.FarmerID = fp.FarmerID
GROUP BY f.Region
HAVING COUNT(fp.FarmerProductID) > 0
ORDER BY TotalProducts DESC;