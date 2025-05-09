SELECT f.FarmName, SUM(fp.Price * fp.Stock) AS InventoryValue
FROM FarmerProducts fp
JOIN Farmers f ON fp.FarmerID = f.FarmerID
GROUP BY f.FarmName;
