using SchoolApp.Core;
using SchoolApp.Models;
using System.Linq.Expressions;

namespace SchoolApp.Repositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {

        Task<List<Course>> GetTeacherCoursesAsync(int teacherId);
        Task<User?> GetUserTeacherByUsernameAsync(string username);
        Task<PaginatedResult<Teacher>> GetPaginatedTeachersAsync(int pageNumber, int pageSize,
            List<Expression<Func<Teacher, bool>>> predicates);
    }
}
