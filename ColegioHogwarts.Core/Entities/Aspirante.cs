using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ColegioHogwarts.Core.Entities
{
    public partial class Aspirante
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
        public enum CasaPertenece
        {
            Gryffindor = 1,
            Hufflepuff = 2,
            Ravenclaw = 3,
            Slytherin = 4
        }
    }
}
