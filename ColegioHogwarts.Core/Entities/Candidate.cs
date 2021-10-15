using System;
using System.ComponentModel.DataAnnotations;

namespace ColegioHogwarts.Core.Entities
{
    public class Candidate
    {
        [MaxLength(10)]
        public int Id { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Apellido { get; set; }

        [MaxLength(2)]
        public int Edad { get; set; }
        public CasaPertenece Casa { get; set; }

        public enum CasaPertenece { 
            Gryffindor = 1,
            Hufflepuff = 2,
            Ravenclaw = 3, 
            Slytherin = 4
        }
    }
}   
