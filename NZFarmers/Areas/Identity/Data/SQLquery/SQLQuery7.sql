SELECT f.FarmName
FROM Farmers f
LEFT JOIN FarmerProducts fp ON f.FarmerID = fp.FarmerID
WHERE fp.FarmerProductID IS NULL;
