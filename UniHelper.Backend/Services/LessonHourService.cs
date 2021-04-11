using System;
using System.Linq;
using AutoMapper;
using Karcags.Common.Tools;
using Karcags.Common.Tools.Services;
using Microsoft.EntityFrameworkCore;
using UniHelper.Backend.Entities;
using UniHelper.Shared.DTOs;

namespace UniHelper.Backend.Services
{
    /// <inheritdoc cref="UniHelper.Backend.Services.ILessonHourService" />
    public class LessonHourService : Repository<LessonHour>, ILessonHourService
    {
        /// <summary>
        /// Init Lesson Hour Service
        /// </summary>
        /// <param name="context">Database Context</param>
        /// <param name="logger">Logger</param>
        /// <param name="utils">Utils Service</param>
        /// <param name="mapper">Mapper</param>
        public LessonHourService(DatabaseContext context, ILoggerService logger, IUtilsService utils, IMapper mapper) : base(context, logger, utils, mapper, "LessonHour")
        {
        }

        /// <inheritdoc />
        public LessonHourIntervalDto GetHourInterval(int from, int to)
        {
            if (from > to)
            {
                throw new ArgumentException("From has to be before to");
            }
            
            var list = GetAll();
            var fromHour = list.FirstOrDefault(x => x.Number == from);
            var toHour = list.FirstOrDefault(x => x.Number == to);

            if (fromHour == null || toHour == null)
            {
                throw new ArgumentException("From and to have to be valid row numbers");
            }

            return new LessonHourIntervalDto
            {
                Start = fromHour.Start,
                End = toHour.End
            };
        }
    }
}