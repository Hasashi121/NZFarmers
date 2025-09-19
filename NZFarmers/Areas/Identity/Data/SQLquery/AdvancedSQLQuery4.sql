WITH CategoryStats AS (
    SELECT 
        Category,
        COUNT(*) as ProductCount,
        AVG(Price) as AvgPrice,
        SUM(Stock) as TotalStock,
        COUNT(DISTINCT FarmerID) as FarmerCount
    FROM FarmerProducts
    GROUP BY Category
)
SELECT 
    cs.Category,
    cs.ProductCount,
    cs.AvgPrice,
    cs.TotalStock,
    cs.FarmerCount,
    CAST(cs.ProductCount as FLOAT) / (SELECT SUM(ProductCount) FROM CategoryStats) * 100 as PercentageOfProducts,
    CASE 
        WHEN cs.AvgPrice > (SELECT AVG(AvgPrice) FROM CategoryStats) THEN 'High Value Category'
        ELSE 'Standard Category'
    END as CategoryType
FROM CategoryStats cs
ORDER BY cs.ProductCount DESC;