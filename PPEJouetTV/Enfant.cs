using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEJouetTV
{
    class Enfant
    {
        private int id;
        private int age;
        private string prenom;
        private Utilisateur unEmploye;

        //Construct
        public Enfant(Int32 pId, Int32 pAge, String pPrenom, Utilisateur pUnEmploye)
        {
            id=pId;
            age=pAge;
            prenom = pPrenom;
            unEmploye=pUnEmploye;
        }

        public String Infos
        {
            get { return prenom+" - "+age+" ans"; }
        }
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        //Accesseurs
        public Int32 getId()
        {
            return id;
        }
        public Int32 getAge()
        {
            return age;
        }
        public String getPrenom()
        {
            return prenom;
        }
        public Utilisateur getParent()
        {
            return unEmploye;
        }

        //Mutateurs
        public void setAge(Int32 pAge)
        {
            age = pAge;
        }
        public void setPrenom(String pPrenom)
        {
            prenom = pPrenom;
        }
    }
}
