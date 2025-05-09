SELECT FarmerID, AVG(RatingValue) AS AverageRating
FROM Ratings
GROUP BY FarmerID;
