using ColegioHogwarts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Core.DTOs
{
    public class CandidateDto
    {
        /// <summary>
        /// El campo idCandidate es autoincremental
        /// El campo identification debe contener maximo 10 digitos y no puede ser nulo
        /// El campo name debe contener minimo 3 caracteres, máximo 20 caracteres y no puede ser nulo
        /// El campo lastName debe contener minimo 3 caracteres, máximo 20 caracteres y no puede ser nulo
        /// El campo edad debe contener 2 digitos y no puede ser nulo
        /// En el campo House solo se pueden ingresar las casas Ravenclaw, Slytherin, Gryffindor o Hufflepuff
        /// </summary>
        public int IdCandidate { get; set; }
        public long? Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string House { get; set; }
    }
}
