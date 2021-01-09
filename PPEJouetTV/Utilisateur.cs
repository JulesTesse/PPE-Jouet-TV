using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class Utilisateur
    {
        protected int id;
        protected string mdp;
        protected int TypeU;

        //Construct
        public Utilisateur(Int32 pId, Int32 pType, String pMdp)
        {
            id = pId;
            mdp = pMdp;
            TypeU = pType;
        }

        //Accesseurs
        public Int32 getId()
        {
            return id;
        }
        public Int32 getTypeU()
        {
            return TypeU;
        }
        public String getMdp()
        {
            return mdp;
        }
        public Int32 Infos
        {
            get { return id; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Mutateurs
        public void setMdp(String pMdp)
        {
            mdp = pMdp;
        }
        //Autres méthodes
        public static Boolean verifUtilisateur(Int32 pId, String pMdp)
        {
            Boolean retour = true;

            String requete = "SELECT * FROM Utilisateur WHERE id = " + pId + " AND mdp ='" + pMdp+"'";
            SqlCommand maCommande = new SqlCommand(requete, DAO<Utilisateur>.seConnecter());

            try
            {
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read() == false)
                {
                    retour = false;
                }
            resultat.Close();
            }
            catch
            {
                //System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            
            return retour;
        }

        public override string ToString()
        {
            string retour = "";
            if (TypeU == 2)
            {                
                List<Enfant> lesEnfants = new List<Enfant>(EnfantDAO.findByEmploye(id));
                foreach (Enfant unEnfant in lesEnfants)
                {
                    retour += unEnfant.getPrenom() + "\t" + unEnfant.getAge() + "ans \n";
                }
            }
            else if (TypeU == 1)
            {
                retour = "id = " + id + "  mdp = " + mdp + "  type = " + TypeU;
            }
            return retour;
        }
        
    }
}
