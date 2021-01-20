namespace UniHelper.Backend.Models
{
    public class SubjectModel
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public int? Result { get; set; }
        public bool IsActive { get; set; }
        public int PeriodId { get; set; }
    }
}