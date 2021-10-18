namespace ColegioHogwarts.Core.Entities
{
    public partial class Candidate : BaseEntity
    {
        public long Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string House { get; set; }
    }
}
