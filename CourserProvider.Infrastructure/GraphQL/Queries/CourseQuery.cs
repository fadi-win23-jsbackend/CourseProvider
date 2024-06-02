using CourserProvider.Infrastructure.Models;
using CourserProvider.Infrastructure.Services;

namespace CourserProvider.Infrastructure.GraphQL.Queries;

public class CourseQuery(ICourseService courseService)
{

    private readonly ICourseService _courseService = courseService;

    [GraphQLName("getCourses")]
    public async Task<IEnumerable<Course>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }

    [GraphQLName("getCourseById")]
    public async Task<Course> GetCourseByItAsync(string id)
    {
        return await _courseService.GetCourseByIdAsync(id);
    }

}
