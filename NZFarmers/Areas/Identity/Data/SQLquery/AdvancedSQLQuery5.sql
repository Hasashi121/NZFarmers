WITH EventStats AS (
    SELECT 
        fme.EventID,
        fme.Title,
        fme.Location,
        fme.Date,
        DATEDIFF(day, GETDATE(), fme.Date) as DaysUntilEvent
    FROM FarmerMarketEvents fme
    WHERE fme.Date >= GETDATE()
)
SELECT 
    es.Title,
    es.Location,
    es.Date,
    es.DaysUntilEvent,
    CASE 
        WHEN es.DaysUntilEvent <= 7 THEN 'This Week'
        WHEN es.DaysUntilEvent <= 30 THEN 'This Month'
        WHEN es.DaysUntilEvent <= 90 THEN 'Next 3 Months'
        ELSE 'Future Events'
    END as EventTimeline,
    DATENAME(weekday, es.Date) as DayOfWeek,
    DATENAME(month, es.Date) as EventMonth
FROM EventStats es
ORDER BY es.Date ASC;