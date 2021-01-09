using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPEJouetTV
{
    class Jouet
    {
        private int id;
        private string libelle;
        private Categorie uneCateg;
        private TrancheAge uneTranche;

        //Construct
        public Jouet(int pId, string pLibelle, Categorie pUneCateg, TrancheAge pUneTranche)
        {
            id = pId;
            libelle = pLibelle;
            uneCateg = pUneCateg;
            uneTranche = pUneTranche;
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

        public Categorie getCategorie()
        {
            return uneCateg;
        }

        public TrancheAge getTrancheAge()
        {
            return uneTranche;
        }
    }
}
