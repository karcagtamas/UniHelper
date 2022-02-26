using AutoMapper;
using KarcagS.Common.Tools.Repository;
using KarcagS.Common.Tools.Services;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;

namespace UniHelper.Backend.Services;

/// <inheritdoc cref="ISubjectService" />
public class SubjectService : MapperRepository<Subject, int>, ISubjectService
{
    /// <summary>
    /// Init Subject Service
    /// </summary>
    /// <param name="context">Database Context</param>
    /// <param name="logger">Logger</param>
    /// <param name="utils">Utils Service</param>
    /// <param name="mapper">Mapper</param>
    public SubjectService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "Subject")
    {
    }
}
