using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEJouetTV
{
    class Cadeau
    {
        private Enfant unEnfant;
        private Jouet unJouet;
        private DateTime date;

        //Construct
        public Cadeau(Enfant pUnEnfant, Jouet pUnJouet, DateTime pDate)
        {
            unEnfant = pUnEnfant;
            unJouet = pUnJouet;
            date = pDate;
        }

        //Accesseurs
        public DateTime getDate()
        {
            return date;
        }
        public Enfant getEnfant()
        {
            return unEnfant;
        }
        public Jouet getJouet()
        {
            return unJouet;
        }
        //Mutateurs
        public void setDate(DateTime pDate)
        {
            date = pDate;
        }
    }
}
