using ColegioHogwarts.Core.Interfaces;
using System.Collections.Generic;

namespace ColegioHogwarts.Infraestructure.Validators
{
    public class HouseValidator : IHouseValidator
    {
        public bool HouseExist(string house)
        {
            bool exists = true;
            List<string> houseAspire = new List<string>() { "Gryffindor", "Slytherin", "Ravenclaw", "Hufflepuff" };

            if (!houseAspire.Contains(house))
                return false;

            return exists;
        }
    }
}
