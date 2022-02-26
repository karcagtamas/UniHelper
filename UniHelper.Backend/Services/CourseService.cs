using AutoMapper;
using KarcagS.Common.Tools.Repository;
using KarcagS.Common.Tools.Services;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;

namespace UniHelper.Backend.Services;

/// <inheritdoc cref="Interfaces.ICourseService" />
public class CourseService : MapperRepository<Course, int>, ICourseService
{
    /// <summary>
    /// Init Course Service
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="logger">Logger</param>
    /// <param name="utils">Utils Service</param>
    /// <param name="mapper">Mapper</param>
    public CourseService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) :
        base(context, logger, utils, mapper, "Course")
    {
    }
}
