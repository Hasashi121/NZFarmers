SELECT FarmerID, COUNT(*) AS ProductCount
FROM FarmerProducts
GROUP BY FarmerID;
