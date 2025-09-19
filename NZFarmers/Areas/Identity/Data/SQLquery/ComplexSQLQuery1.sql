SELECT f.FarmName, fp.ProductName, fp.Price, fp.Stock
FROM Farmers f
INNER JOIN FarmerProducts fp ON f.FarmerID = fp.FarmerID
WHERE fp.Stock > 0;