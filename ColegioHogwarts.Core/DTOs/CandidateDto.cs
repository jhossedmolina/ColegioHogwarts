using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Core.DTOs
{
    public class CandidateDto
    {
        public int Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string House { get; set; }
    }
}
