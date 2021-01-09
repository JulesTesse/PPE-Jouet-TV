using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEJouetTV
{
    class Categorie
    {
        private int id;
        private string libelle;

        //Construct
        public Categorie(int pId, string pLibelle)
        {
            id = pId;
            libelle = pLibelle;
        }

        public String Infos
        {
            get { return libelle; }
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
        public String getLibelle()
        {
            return libelle;
        }

        //Mutateurs
        public void setLibelle(String pLibelle)
        {
            libelle = pLibelle;
        }

        public override string ToString()
        {
            return libelle;
        }
    }
}
