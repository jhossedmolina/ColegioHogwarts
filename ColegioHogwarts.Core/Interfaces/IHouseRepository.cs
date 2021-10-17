using System;
using System.Collections.Generic;
using System.Text;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface IHouseRepository
    {
        bool HouseExist(string house);
    }
}
