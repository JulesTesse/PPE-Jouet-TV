using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class JouetDAO : DAO<Jouet>
    {
        //Create
        public override bool create(Jouet unJouet)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO Jouet VALUES (@id, @libelle @idCategorie, @idTranche)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", unJouet.getId());
                maCommande.Parameters.AddWithValue("@libelle", unJouet.getLibelle());
                maCommande.Parameters.AddWithValue("@idCategorie", unJouet.getCategorie().getId());
                maCommande.Parameters.AddWithValue("@nbEnfants", unJouet.getTrancheAge().getId());
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
        public override Jouet find(int pId)
        {
            Jouet unJouet = null;
            try
            {
                String requete = "SELECT * FROM Jouet WHERE id =" + pId;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                if (resultat.Read())
                {
                    int id = (int)resultat["id"];
                    string libelle = (string)resultat["libelle"];
                    int idCategorie = (int)resultat["idCategorie"];
                    int idTranche = (int)resultat["idTranche"];
                    CategorieDAO uneCategorieDAO = new CategorieDAO();
                    Categorie uneCategorie = uneCategorieDAO.find(idCategorie);
                    TrancheDAO uneTrancheDAO = new TrancheDAO();
                    TrancheAge uneTranche = uneTrancheDAO.find(idTranche);
                    unJouet = new Jouet(id, libelle, uneCategorie, uneTranche);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
        
            return unJouet;
        }

        //Update
        public override bool update(Jouet unJouet)
        {
            Boolean retour = false;
            try
            {
                String requete = "UPDATE Jouet SET libelle=@libelle, idCategorie=@uneCateg, idTranche=@uneTranche WHERE id=" + unJouet.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@libelle", unJouet.getLibelle());
                maCommande.Parameters.AddWithValue("@uneCateg", unJouet.getCategorie().getId());
                maCommande.Parameters.AddWithValue("@uneTranche", unJouet.getTrancheAge().getId());
                Int32 result = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return retour;
        }

        //Delete
        public override bool delete(Jouet unJouet)
        {
            Boolean retour = false;
            try
            {
                String requete = "DELETE FROM Jouet WHERE id=" + unJouet.getId();
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

        public static List<Jouet> findByTrancheCateg(TrancheAge uneTranche, Categorie uneCateg)
        {
            List<Jouet> lesJouets = new List<Jouet>();
            try
            {
                String requete = "SELECT * FROM Jouet WHERE idTranche = " + uneTranche.getId() + " AND idCategorie = " + uneCateg.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                while (resultat.Read())
                {
                    int id = (int)resultat["id"];
                    string libelle = (string)resultat["libelle"];
                    Jouet unJouet = new Jouet(id, libelle, uneCateg, uneTranche);
                    lesJouets.Add(unJouet);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return lesJouets;
        }

        public static Jouet findByNom(String pNom)
        {
            String requete = "SELECT * FROM Jouet WHERE libelle = '"+ pNom +"'";
            SqlCommand maCommande = new SqlCommand(requete, seConnecter());
            SqlDataReader resultat = maCommande.ExecuteReader();

            Jouet unJouet = null;
            if (resultat.Read())
            {
                int id = (int)resultat["id"];
                int idCategorie = (int)resultat["idCategorie"];
                int idTranche = (int)resultat["idTranche"];
                CategorieDAO uneCategorieDAO = new CategorieDAO();
                Categorie uneCategorie = uneCategorieDAO.find(idCategorie);
                TrancheDAO uneTrancheDAO = new TrancheDAO();
                TrancheAge uneTranche = uneTrancheDAO.find(idTranche);
                unJouet = new Jouet(id, pNom, uneCategorie, uneTranche);
            }
            resultat.Close();
            return unJouet;
        }

        public static List<Jouet> findByCateg(Categorie uneCateg)
        {
            List<Jouet> lesJouets = new List<Jouet>();
            try
            {
                String requete = "SELECT * FROM Jouet WHERE idCategorie = " + uneCateg.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                while (resultat.Read())
                {
                    int id = (int)resultat["id"];
                    string libelle = (string)resultat["libelle"];
                    TrancheDAO uneTrancheDAO = new TrancheDAO();
                    TrancheAge uneTranche = uneTrancheDAO.find((int)resultat["idTranche"]);
                    Jouet unJouet = new Jouet(id, libelle, uneCateg, uneTranche);
                    lesJouets.Add(unJouet);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return lesJouets;
        }
    }
}
