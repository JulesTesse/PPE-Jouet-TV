using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class CategorieDAO : DAO<Categorie>
    {
        //Create
        public override bool create(Categorie uneCategorie)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO Categorie VALUES (@id, @libelle)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", uneCategorie.getId());
                maCommande.Parameters.AddWithValue("@age", uneCategorie.getLibelle());
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
        public override Categorie find(int pId)
        {
            Categorie uneCategorie = null;
            try
            {
                String requete = "SELECT * FROM Catégorie WHERE id = " + pId;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read())
                {
                    string libelle = (string)resultat["libelle"];
                    uneCategorie = new Categorie(pId, libelle);
                }
                else
                {

                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return uneCategorie;
        }
        //Update
        public override bool update(Categorie uneCategorie)
        {
            Boolean retour = false;
            try
            {
                String requete = "UPDATE Categorie SET libelle=@libelle WHERE id=@id";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", uneCategorie.getId());
                maCommande.Parameters.AddWithValue("@libelle", uneCategorie.getLibelle());
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
        public override bool delete(Categorie uneCategorie)
        {
            List<Jouet> sesJouets = JouetDAO.findByCateg(uneCategorie);
            if (sesJouets.Count() != 0)
            {
                try
                {
                    JouetDAO unDAO = new JouetDAO();
                    foreach (Jouet j in sesJouets)
                    {
                        unDAO.delete(j);
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Oups: " + ex);
                }
            }
            Boolean retour = false;
            try
            {
                String requete = "DELETE FROM Categorie WHERE id =" + uneCategorie.getId();
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

        //FindAll
        public static List<Categorie> findAll()
        {
            List<Categorie> lesCategories = new List<Categorie>();
            try
            {
                String requete = "SELECT * FROM Catégorie";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                while (resultat.Read())
                {
                    int id = (int)resultat["id"];
                    string libelle = (string)resultat["libelle"];
                    Categorie uneCategorie = new Categorie(id, libelle);
                    lesCategories.Add(uneCategorie);
                }

                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return lesCategories;
        }
    }
}
