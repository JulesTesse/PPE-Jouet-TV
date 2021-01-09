using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEJouetTV
{
    class TrancheAge
    {
        private int id;
        private int ageMin, ageMax;

        //Construct
        public TrancheAge(Int32 pId, Int32 pAgeMin, Int32 pAgeMax)
        {
            id = pId;
            ageMin = pAgeMin;
            ageMax = pAgeMax;
        }

        //Accesseurs
        public Int32 getId()
        {
            return id;
        }
        public Int32 getAgeMin()
        {
            return ageMin;
        }
        public Int32 getAgeMax()
        {
            return ageMax;
        }

        //Mutateurs
        public void setAgeMin(Int32 pAgeMin)
        {
            ageMin = pAgeMin;
        }
        public void setAgeMax(Int32 pAgeMax)
        {
            ageMax = pAgeMax;
        }
    }
}
