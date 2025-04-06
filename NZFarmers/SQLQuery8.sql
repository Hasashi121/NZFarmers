WITH RankedProducts AS (
    SELECT ProductName, Price,
           RANK() OVER (ORDER BY Price DESC) AS RankPosition
    FROM FarmerProducts
)
SELECT * FROM RankedProducts
WHERE RankPosition <= 3;
