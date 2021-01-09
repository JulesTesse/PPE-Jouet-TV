using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class UtilisateurDAO:DAO<Utilisateur>
    {
        //Create
        public override bool create(Utilisateur unUtilisateur)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO Utilisateur VALUES (@id, @idU, @mdp)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@id", unUtilisateur.getId());
                maCommande.Parameters.AddWithValue("@mdp", unUtilisateur.getMdp());
                maCommande.Parameters.AddWithValue("@idU", unUtilisateur.getTypeU());
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
        public override Utilisateur find(int pId)
        {
            Utilisateur unUtilisateur = null;
            try
            {
                String requete = "SELECT * FROM Utilisateur WHERE id =" + pId;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read())
                {
                    int idTypeU = (int)resultat["idTypeU"];
                    string mdp = (string)resultat["mdp"];
                    unUtilisateur = new Utilisateur(pId, idTypeU, mdp);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }

            return unUtilisateur;
        }

        //Update
        public override bool update(Utilisateur unUtilisateur)
        {
            Boolean retour = false;
            try
            {
                String requete = "UPDATE Utilisateur SET idTypeU=@typeU, mdp=@mdp WHERE id=" + unUtilisateur.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@typeU", unUtilisateur.getTypeU());
                maCommande.Parameters.AddWithValue("@mdp", unUtilisateur.getMdp());
                Int32 result = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch(Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return retour;
        }

        //Delete
        public override bool delete(Utilisateur unUtilisateur)
        {
            List<Enfant> sesEnfants = EnfantDAO.findByEmploye(unUtilisateur.getId());
            if(sesEnfants.Count() != 0)
            {
                try
                {
                    EnfantDAO unDAO = new EnfantDAO();
                    foreach (Enfant e in sesEnfants)
                    {
                        unDAO.delete(e);
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
                String requete = "DELETE FROM Utilisateur WHERE id=" + unUtilisateur.getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                Int32 resultat = maCommande.ExecuteNonQuery();
                retour = true;
            }
            catch(Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return retour;
        }

        //Find all employes
        public static List<Utilisateur> findAllEmployes()
        {
            List<Utilisateur> listeEmployes = new List<Utilisateur>();
            try
            {
                String requete = "SELECT * FROM Utilisateur WHERE idTypeU = 2";
                SqlCommand myCmd = new SqlCommand(requete, seConnecter());
                SqlDataReader result = myCmd.ExecuteReader();


                while (result.Read())
                {
                    int id = (int)result["id"];
                    string mdp = (string)result["mdp"];

                    Utilisateur unEmploye = new Utilisateur(id, 2, mdp);
                    listeEmployes.Add(unEmploye);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return listeEmployes;
        }
    }
}
