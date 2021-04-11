using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.ICourseService" />
    public class CourseService : Repository<Course>, ICourseService
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
}