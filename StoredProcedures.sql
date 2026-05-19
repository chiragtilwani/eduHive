CREATE PROCEDURE sp_GetAllCourses
@Id INT = NULL
AS
BEGIN
	SET NOCOUNT ON;
	with AverageAndTotalRatingCTE as (
		SELECT CourseId,AVG(r.Rating) as AverageRating,COUNT(DISTINCT r.ReviewId) as TotalRating
		FROM Review r
		GROUP BY CourseId
	)

	SELECT c.CourseId, c.Title, c.Description,
		c.Price, c.CourseType, c.SeatsAvailable,
		c.Duration, u.DisplayName AS InstructorDisplayName,
		c.StartDate, c.EndDate, cc.CategoryName AS Category,
		ISNULL(cte.AverageRating,0) AS AverageRating, ISNULL(cte.TotalRating,0) AS TotalRating,
		r.ReviewId,r.CourseId, r.UserId, r.Rating, r.Comment, r.ReviewDate,
		s.SessionId, s.CourseId, s.Title, s.Description, s.VideoUrl, s.VideoOrder
	FROM Course c
	LEFT JOIN Instructor i ON c.InstructorId = i.InstructorId
	LEFT JOIN UserProfile u ON i.UserId = u.UserId
	LEFT JOIN CourseCategory cc ON c.CategoryId = cc.CategoryId
	LEFT JOIN Review r ON c.CourseId = r.CourseId
	LEFT JOIN SessionDetails s ON s.CourseId = c.CourseId
	LEFT JOIN AverageAndTotalRatingCTE cte ON cte.CourseId=c.CourseId
	WHERE (@Id IS NULL OR @Id=c.CourseId)
END;