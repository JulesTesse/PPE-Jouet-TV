using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    class CadeauDAO:DAO<Cadeau>
    {
        //Create
        public override bool create(Cadeau unCadeau)
        {
            Boolean retour = false;
            try
            {
                String requete = "INSERT INTO Cadeau VALUES (@idE, @idJ, @date)";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@idE", unCadeau.getEnfant().getId());
                maCommande.Parameters.AddWithValue("@idJ", unCadeau.getJouet().getId());
                maCommande.Parameters.AddWithValue("@date", unCadeau.getDate());
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
        public override Cadeau find(int pIdE)
        {
            Cadeau unCadeau = null;
            EnfantDAO unEnfantDAO = new EnfantDAO();
            JouetDAO unJouetDAO = new JouetDAO();
            try
            {
                String requete = "SELECT * FROM Cadeau WHERE idEnfant = " + pIdE;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read())
                {
                    int idEnfant = (int)resultat["idEnfant"];
                    int idJouet = (int)resultat["idJouet"];
                    DateTime date = (DateTime)resultat["date"];
                    Enfant unEnfant = unEnfantDAO.find(idEnfant);
                    Jouet unJouet = unJouetDAO.find(idJouet);
                    unCadeau = new Cadeau(unEnfant, unJouet, date);
                }
                resultat.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return unCadeau;
        }
        //Update
        public override bool update(Cadeau unCadeau)
        {
            Boolean retour = false;
            try
            {
                String requete = "UPDATE Cadeau SET date=@date, idJouet=@jouet WHERE idEnfant=" + unCadeau.getEnfant().getId();
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                maCommande.Parameters.AddWithValue("@date", unCadeau.getDate());
                maCommande.Parameters.AddWithValue("@jouet", unCadeau.getJouet().getId());
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
        public override bool delete(Cadeau unCadeau)
        {
            Boolean retour = false;
            try
            {
                String requete = "DELETE FROM Cadeau WHERE idEnfant =" + unCadeau.getEnfant().getId()+" AND idJouet="+unCadeau.getJouet().getId();
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

        //AFFICHAGE CADEAUX ENFANTS DE L'EMPLOYE CONNECTE
        public static List<Cadeau> findEnfants(int pIdEmploye)
        {
            List<Cadeau> lesCadeaux = new List<Cadeau>();

            try
            {
                String requete = "SELECT * FROM Cadeau WHERE idEnfant IN (SELECT id FROM Enfant WHERE idUtilisateur = " + pIdEmploye + ")";
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();

                while (resultat.Read())
                {
                    int idEnfant = (int)resultat["idEnfant"];
                    int idJouet = (int)resultat["idJouet"];
                    DateTime date = (DateTime)resultat["date"];
                    EnfantDAO unEnfantDAO = new EnfantDAO();
                    JouetDAO unJouetDAO = new JouetDAO();
                    Enfant unEnfant = unEnfantDAO.find(idEnfant);
                    Jouet unJouet = unJouetDAO.find(idJouet);
                    Cadeau unCadeau = new Cadeau(unEnfant, unJouet, date);
                    lesCadeaux.Add(unCadeau);
                }
                resultat.Close();
            }
            catch(Exception ex)
            {
                throw new Exception("Oups: " + ex);
            }
            return lesCadeaux;
        }

        public Cadeau findByEnfant(Int32 idE){
            Cadeau unCadeau = null;
            try
            {
                String requete = "SELECT * FROM Cadeau WHERE idEnfant = " + idE;
                SqlCommand maCommande = new SqlCommand(requete, seConnecter());
                SqlDataReader resultat = maCommande.ExecuteReader();
                if (resultat.Read())
                {
                    int idEnfant = (int)resultat["idEnfant"];
                    int idJouet = (int)resultat["idJouet"];
                    DateTime date = (DateTime)resultat["date"];
                    EnfantDAO unEnfantDAO = new EnfantDAO();
                    JouetDAO unJouetDAO = new JouetDAO();
                    Enfant unEnfant = unEnfantDAO.find(idEnfant);
                    Jouet unJouet = unJouetDAO.find(idJouet);
                    unCadeau = new Cadeau(unEnfant, unJouet, date);
                }
                else
                {

                }
                resultat.Close();
            }
            catch
            {

            }
            return unCadeau;
        }
    }
}
