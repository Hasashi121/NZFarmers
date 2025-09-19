SELECT 
    f.FarmName,
    f.Region,
    COUNT(fp.FarmerProductID) as TotalProducts,
    AVG(fp.Price) as AvgPrice,
    RANK() OVER (PARTITION BY f.Region ORDER BY COUNT(fp.FarmerProductID) DESC) as RegionRank
FROM Farmers f
LEFT JOIN FarmerProducts fp ON f.FarmerID = fp.FarmerID
GROUP BY f.FarmerID, f.FarmName, f.Region;