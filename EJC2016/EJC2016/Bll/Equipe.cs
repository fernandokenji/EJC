using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EJC2016.IDal;
using EJC2016.Dal;

namespace EJC2016.Bll
{
    public class Equipe : IEquipeDal
    {
        public List<int> GetIdEquipes()
        {
            var EquipeDal = new EquipeDal();
            return EquipeDal.GetIdEquipes();
        }
    }
}
