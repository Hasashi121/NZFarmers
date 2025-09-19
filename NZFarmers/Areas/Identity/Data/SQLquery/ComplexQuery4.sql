SELECT Title, Description, CreatedAt
FROM EducationalContents
WHERE CreatedAt >= DATEADD(day, -30, GETDATE())
ORDER BY CreatedAt DESC;