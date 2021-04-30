using System.Collections.Generic;

namespace UniHelper.Shared.DTOs
{
    /// <summary>
    /// Statistic for Home page
    /// </summary>
    public class StatisticDto
    {
        /// <summary>
        /// Solved tasks
        /// </summary>
        public int SolvedTasks { get; set; }

        /// <summary>
        /// Unsolved tasks
        /// </summary>
        public int UnSolvedTasks { get; set; }

        /// <summary>
        /// Period statistics
        /// </summary>
        public List<PeriodStatistic> Periods { get; set; } = new List<PeriodStatistic>();
    }

    /// <summary>
    /// Period Statistic
    /// </summary>
    public class PeriodStatistic {
        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; set; } = "";

        /// <summary>
        /// Is current
        /// </summary>
        public bool IsCurrent { get; set; }

        /// <summary>
        /// Marks
        /// </summary>
        public List<int> Marks { get; set; } = new List<int>();
    }
}