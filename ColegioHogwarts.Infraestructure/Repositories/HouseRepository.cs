using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ColegioHogwarts.Infraestructure.Repositories
{
    public class HouseRepository : IHouseRepository
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
