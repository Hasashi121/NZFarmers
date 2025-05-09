SELECT fp.*
FROM FarmerProducts fp
WHERE Price = (
    SELECT MAX(Price)
    FROM FarmerProducts
    WHERE FarmerID = fp.FarmerID
);
