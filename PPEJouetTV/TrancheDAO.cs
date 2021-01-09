using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class TrancheDAO:DAO<TrancheAge>
    {
        //Create
        public override bool create(TrancheAge uneTranche)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO TrancheAge VALUES (@id, @ageMin, @ageMax)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", uneTranche.getId());
                maCommande.Parameters.AddWithValue("@ageMin", uneTranche.getAgeMin());
                maCommande.Parameters.AddWithValue("@ageMax", uneTranche.getAgeMax());
                Int32 result = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }

            return retour;
        }

        //Read
        public override TrancheAge find(int pId)
        {
            TrancheAge uneTranche = null;
            try
            {
                String requete = "SELECT * FROM TrancheAge WHERE id = " + pId;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                if (resultat.Read())
                {
                    int id = (int)resultat["id"];
                    int ageMin = (int)resultat["ageMin"];
                    int ageMax = (int)resultat["ageMax"];
                    uneTranche = new TrancheAge(id, ageMin, ageMax);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return uneTranche;
        }

        //Update
        public override bool update(TrancheAge uneTranche)
        {
            Boolean retour = false;
            try
            {
                String requete = "UPDATE TrancheAge SET ageMin=@ageMin, ageMax=@ageMax WHERE id =" + uneTranche.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@ageMin", uneTranche.getAgeMin());
                maCommande.Parameters.AddWithValue("@ageMax", uneTranche.getAgeMax());
                Int32 resultat = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return retour;
        }

        //Delete
        public override bool delete(TrancheAge uneTranche)
        {
            Boolean retour = false;
            try
            {
                String requete = "DELETE FROM TrancheAge WHERE id =" + uneTranche.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                Int32 resultat = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return retour;
        }
    }
}
