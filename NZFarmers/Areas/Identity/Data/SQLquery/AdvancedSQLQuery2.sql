WITH ProductStats AS (
    SELECT 
        fp.ProductName,
        f.FarmName,
        fp.Price,
        fp.Stock,
        fp.Category,
        AVG(fp.Price) OVER (PARTITION BY fp.Category) as CategoryAvgPrice
    FROM FarmerProducts fp
    INNER JOIN Farmers f ON fp.FarmerID = f.FarmerID
)
SELECT 
    ProductName,
    FarmName,
    Price,
    Stock,
    CategoryAvgPrice,
    CASE 
        WHEN Price > CategoryAvgPrice THEN 'Premium'
        WHEN Price < CategoryAvgPrice * 0.8 THEN 'Budget'
        ELSE 'Standard'
    END as PriceCategory,
    CASE 
        WHEN Stock < 50 THEN 'Low Stock'
        WHEN Stock > 200 THEN 'High Stock'
        ELSE 'Normal Stock'
    END as StockLevel
FROM ProductStats;