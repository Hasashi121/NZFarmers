SELECT fp.ProductName, f.FarmName, fp.Price
FROM FarmerProducts fp
JOIN Farmers f ON fp.FarmerID = f.FarmerID;
