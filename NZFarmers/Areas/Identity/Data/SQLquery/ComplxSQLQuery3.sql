SELECT f.FarmName, f.City, COUNT(fp.FarmerProductID) as ProductCount
FROM Farmers f
LEFT JOIN FarmerProducts fp ON f.FarmerID = fp.FarmerID
GROUP BY f.FarmerID, f.FarmName, f.City
ORDER BY ProductCount DESC;