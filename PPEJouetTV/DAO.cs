using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    abstract class DAO<T>
    {
        private static SqlConnection laConnexion = null;
        //Create
        public abstract Boolean create(T unObjet);

        //Read
        public abstract T find(int id);

        //Update
        public abstract Boolean update(T unObjet);

        //Delete
        public abstract Boolean delete(T unObjet);

        //Connexion
        public static SqlConnection seConnecter()
        {
            if (laConnexion == null)
            {
                laConnexion = new SqlConnection();
                //laConnexion.ConnectionString = "Data Source=WIN-921C8FKTGAE; Initial Catalog=slam2018PPEJouetTV; User ID=tesse; Password=tesse;MultipleActiveResultSets=true";
                //laConnexion.ConnectionString = "Data Source=LUCAS\\SQLEXPRESS; Initial Catalog=slam2018PPEJouetTV; User ID=vouters; Password=vouters;MultipleActiveResultSets=true";
                laConnexion.ConnectionString = "Data Source=DESKTOP-NIRTALN\\SQLEXPRESS; Initial Catalog=slam2018PPEJouetTV; User ID=jules; Password=tnU977cR;MultipleActiveResultSets=true";
                laConnexion.Open();
                System.Diagnostics.Debug.WriteLine("Instanciation Connexion");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Connexion existe déjà");
            }
            return laConnexion;
        }

        //Selectionne le numero max d'une table
        public static Int32 NumMax(String nomTable, String nomColonne)
        {
            Int32 numMax = 0;
            seConnecter();
            String requete = "SELECT MAX(" + nomColonne + ") FROM " + nomTable;
            SqlCommand maCommande = new SqlCommand(requete, seConnecter());
            numMax = (int)maCommande.ExecuteScalar();
            return (numMax + 1);

        }
    }
}
