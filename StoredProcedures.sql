-- GetCourseById
CREATE PROCEDURE sp_GetCourseByID
	@Id int
AS
BEGIN
	SET NOCOUNT ON;
	WITH AverageAndTotalRatingCTE AS (
		select CourseId, AVG(Rating) AS AverageRating,COUNT(DISTINCT ReviewId) AS TotalRating 
		FROM Review
		WHERE CourseId = @Id
		GROUP BY CourseId
	)
SELECT c.CourseId, c.Title, c.Description,
    c.Price, c.CourseType, c.SeatsAvailable,
    c.Duration, u.DisplayName AS InstructorDisplayName,
    c.StartDate, c.EndDate, cc.CategoryName AS Category,
	ISNULL(cte.AverageRating,0) AS AverageRating,ISNULL(cte.TotalRating,0) AS TotalRating,
    r.ReviewId,r.CourseId, r.UserId, r.Rating, r.Comment, r.ReviewDate,
    s.SessionId, s.CourseId, s.Title, s.Description, s.VideoUrl, s.VideoOrder
FROM Course c
LEFT JOIN Instructor i ON c.InstructorId = i.InstructorId
LEFT JOIN UserProfile u ON i.UserId = u.UserId
LEFT JOIN CourseCategory cc ON c.CategoryId = cc.CategoryId
LEFT JOIN Review r ON c.CourseId = r.CourseId
LEFT JOIN SessionDetails s ON c.CourseId = s.CourseId
LEFT JOIN AverageAndTotalRatingCTE cte ON c.CourseId=cte.CourseId
WHERE c.CourseId = @Id;

END