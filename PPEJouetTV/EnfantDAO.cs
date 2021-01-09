using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class EnfantDAO:DAO<Enfant>
    {
        //Create
        public override bool create(Enfant unEnfant)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO Enfant VALUES (@id, @age, @prenom, @idU)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", unEnfant.getId());
                maCommande.Parameters.AddWithValue("@age", unEnfant.getAge());
                maCommande.Parameters.AddWithValue("@prenom", unEnfant.getPrenom());
                maCommande.Parameters.AddWithValue("@idU", unEnfant.getParent().getId());
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
        public override Enfant find(int pId)
        {
            Enfant unEnfant = null;
            try
            {
                String requete = "SELECT * FROM Enfant WHERE id=" + pId;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read())
                {
                    int age = (int)resultat["age"];
                    string prenom = (string)resultat["prenom"];
                    int idUtilisateur = (int)resultat["idUtilisateur"];
                    UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                    Utilisateur unEmploye = unUtilisateurDAO.find(idUtilisateur);
                    unEnfant = new Enfant(pId, age, prenom, unEmploye);
                }
                

                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return unEnfant;
        }
        //Update
        public override bool update(Enfant unEnfant)
        {
            Boolean retour = false;
            try
            {                
                String requete = "UPDATE Enfant SET age=@age, prenom=@prenom, idUtilisateur=@idU WHERE id=@id";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", unEnfant.getId());
                maCommande.Parameters.AddWithValue("@age", unEnfant.getAge());
                maCommande.Parameters.AddWithValue("@prenom", unEnfant.getPrenom());
                maCommande.Parameters.AddWithValue("@idU", unEnfant.getParent().getId());
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
        public override bool delete(Enfant unEnfant)
        {
            Boolean retour = false;
            try
            {
                String requete = "DELETE FROM Enfant WHERE id =" + unEnfant;
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

        //Find all by employees
        public static List<Enfant> findByEmploye(int pId)
        {
            List<Enfant> lesEnfants = new List<Enfant>();
            String requete = "SELECT * FROM Enfant WHERE idUtilisateur=" + pId;
            SqlCommand maCommande = new SqlCommand(requete, seConnecter());
            SqlDataReader resultat = maCommande.ExecuteReader();

            while (resultat.Read())
            {
                int id = (int)resultat["id"];
                int age = (int)resultat["age"];
                string prenom = (string)resultat["prenom"];
                UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                Enfant unEnfant = new Enfant(id, age, prenom, unUtilisateurDAO.find(pId));
                lesEnfants.Add(unEnfant);
            }
            resultat.Close();
            return lesEnfants;
        }
    }
}
