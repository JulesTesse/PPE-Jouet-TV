using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPEJouetTV
{
    public partial class formResponsable : Form
    {
        public formResponsable()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEmployes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbEnfants.DataSource = EnfantDAO.findByEmploye((Int32)cbEmployes.SelectedValue);
            cbEnfants.DisplayMember = "Infos";
            cbEnfants.ValueMember = "Id";
        }

        private void formResponsable_Load(object sender, EventArgs e)
        {
            cbEmployes.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployes.DisplayMember = "Infos";
            cbEmployes.ValueMember = "Id";

            cbEnfants.DataSource = EnfantDAO.findByEmploye((Int32)cbEmployes.SelectedValue);
            cbEnfants.DisplayMember = "Infos";
            cbEnfants.ValueMember = "Id";

            cbEmployeAff.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployeAff.DisplayMember = "Infos";
            cbEmployeAff.ValueMember = "Id";

            cbAffCateg.DataSource = CategorieDAO.findAll();
            cbAffCateg.DisplayMember = "Infos";
            cbAffCateg.ValueMember = "Id";

            cbCategJouet.DataSource = CategorieDAO.findAll();
            cbCategJouet.DisplayMember = "Infos";
            cbCategJouet.ValueMember = "Id";

            List<Jouet> lesJouets = new List<Jouet>();
            CategorieDAO uneCategDAO = new CategorieDAO();
            Categorie uneCateg = uneCategDAO.find((int)cbCategJouet.SelectedValue);
            try { lesJouets = JouetDAO.findByCateg(uneCateg); }
            catch { MessageBox.Show("Problème avec la fonction pour trouver les jouets."); }
            try
            {
                Int32 i = 0;
                foreach (Jouet j in lesJouets)
                {
                    dGVJouets.Rows.Insert(i, j.getLibelle());
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Impossible d'afficher les jouets des enfants");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int id = DAO<Enfant>.NumMax("Enfant", "id");
            int idEmploye = (Int32)cbEmployes.SelectedValue;
            if (txtBxAge.Text != "" && txtBxPrenom.Text != "")
            {
                string prenom = txtBxPrenom.Text;
                Int32 age = 0;
                if (Int32.TryParse(txtBxAge.Text, out age))
                {
                    UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                    Enfant unEnfant = new Enfant(id, age, prenom, unUtilisateurDAO.find(idEmploye));
                    EnfantDAO enfantDao = new EnfantDAO();
                    Boolean check = enfantDao.create(unEnfant);
                    if (check == true)
                    {
                        MessageBox.Show("Enfant ajouté.");
                    }
                    else
                    {
                        MessageBox.Show("Incident dans l'ajout de l'enfant.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            cbEnfants.DataSource = EnfantDAO.findByEmploye((Int32)cbEmployes.SelectedValue);
            cbEnfants.DisplayMember = "Infos";
            cbEnfants.ValueMember = "Id";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = (Int32)cbEnfants.SelectedValue;
            int idEmploye = (Int32)cbEmployes.SelectedValue;
            EnfantDAO unEnfantDAO = new EnfantDAO();
            Enfant unEnfant = unEnfantDAO.find(id);
            if (tbModifAge.Text != "" && tbModifPrenom.Text != "")
            {
                string prenom = tbModifPrenom.Text;
                Int32 age = 0;
                if (Int32.TryParse(tbModifAge.Text, out age))
                {
                    unEnfant.setAge(age);
                    unEnfant.setPrenom(prenom);
                    Boolean check = unEnfantDAO.update(unEnfant);
                    if (check == true)
                    {
                        MessageBox.Show("Enfant modifié.");

                    }
                    else
                    {
                        MessageBox.Show("Incident dans la modification de l'enfant.");
                    }
                }
            }
            else if (tbModifAge.Text != "")
            {
                Int32 age = 0;
                if (Int32.TryParse(tbModifAge.Text, out age))
                {
                    unEnfant.setAge(age);
                    Boolean check = unEnfantDAO.update(unEnfant);
                    if (check == true)
                    {
                        MessageBox.Show("Enfant modifié.");
                    }
                    else
                    {
                        MessageBox.Show("Incident dans la modification de l'enfant.");
                    }
                }
            }
            else if (tbModifPrenom.Text != "")
            {
                string prenom = tbModifPrenom.Text;
                unEnfant.setPrenom(prenom);
                Boolean check = unEnfantDAO.update(unEnfant);
                if (check == true)
                {
                    MessageBox.Show("Enfant modifié.");
                }
                else
                {
                    MessageBox.Show("Incident dans la modification de l'enfant.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir au moins un des champs ci-dessus.");
            }
            cbEnfants.DataSource = EnfantDAO.findByEmploye((Int32)cbEmployes.SelectedValue);
            cbEnfants.DisplayMember = "Infos";
            cbEnfants.ValueMember = "Id";
        }

        private void btnSupprEnfant_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vous êtes sûr de vouloir supprimer cet enfant?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int idEnfant = (Int32)cbEnfants.SelectedValue;
                UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                EnfantDAO enfantDao = new EnfantDAO();
                Enfant unEnfant = enfantDao.find(idEnfant);
                Boolean check = enfantDao.delete(unEnfant);
                if (check == true)
                {
                    MessageBox.Show("Enfant supprimé.");
                }
                else
                {
                    MessageBox.Show("Incident dans la suppression de l'enfant.");
                }
            }
            else
            {
                MessageBox.Show("Suppression annulée");
            }
            cbEnfants.DataSource = EnfantDAO.findByEmploye((Int32)cbEmployes.SelectedValue);
            cbEnfants.DisplayMember = "Infos";
            cbEnfants.ValueMember = "Id";
        }

        private void btnSupprEmploye_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Vous êtes sûr de vouloir supprimer cet employe?(Et tous ses enfants)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Int32 idEmploye = (Int32)cbEmployeAff.SelectedValue;
                UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                Utilisateur unU = unUtilisateurDAO.find(idEmploye);
                Boolean check = unUtilisateurDAO.delete(unU);
                if (check == true)
                {
                    MessageBox.Show("Employé supprimé.");
                }
                else
                {
                    MessageBox.Show("Incident dans la suppression de l'employé.");
                }
            }
            else
            {
                MessageBox.Show("Suppression annulée");
            }
            cbEmployes.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployes.DisplayMember = "Infos";
            cbEmployes.ValueMember = "Id";

            cbEmployeAff.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployeAff.DisplayMember = "Infos";
            cbEmployeAff.ValueMember = "Id";
        }

        private void tbMdpEmploye_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddEmploye_Click(object sender, EventArgs e)
        {
            if(tbAddMdpEmploye.Text != "")
            {
                int id = DAO<Utilisateur>.NumMax("Utilisateur", "id");
                string mdp = tbAddMdpEmploye.Text;
                UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                Utilisateur unU = new Utilisateur(id, 2, mdp);
                Boolean check = unUtilisateurDAO.create(unU);
                if (check == true)
                {
                    MessageBox.Show("Employé ajouté.");
                }
                else
                {
                    MessageBox.Show("Incident dans l'ajout de l'employé.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            cbEmployes.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployes.DisplayMember = "Infos";
            cbEmployes.ValueMember = "Id";

            cbEmployeAff.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployeAff.DisplayMember = "Infos";
            cbEmployeAff.ValueMember = "Id";
        }

        private void btnModifEmploye_Click(object sender, EventArgs e)
        {
            if (tbModifMdpEmploye.Text != "")
            {
                int id = (Int32)cbEmployeAff.SelectedValue;
                string nvMdp = tbModifMdpEmploye.Text;
                UtilisateurDAO unUtilisateurDAO = new UtilisateurDAO();
                Utilisateur unU = unUtilisateurDAO.find(id);
                unU.setMdp(nvMdp);
                Boolean check = unUtilisateurDAO.update(unU);
                if(check == true)
                {
                    MessageBox.Show("Le mot de passe a bien été modifié.");
                }
                else
                {
                    MessageBox.Show("Incident dans la modification du mot de passe.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
            }
            cbEmployes.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployes.DisplayMember = "Infos";
            cbEmployes.ValueMember = "Id";

            cbEmployeAff.DataSource = UtilisateurDAO.findAllEmployes();
            cbEmployeAff.DisplayMember = "Infos";
            cbEmployeAff.ValueMember = "Id";
        }

        private void btnSupprCateg_Click(object sender, EventArgs e)
        {
            int idCateg = (int)cbAffCateg.SelectedValue;
            var result = MessageBox.Show("Vous êtes sûr de vouloir supprimer cette catégorie?(Et tous les jouets qui y sont reliés)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                CategorieDAO uneDAO = new CategorieDAO();
                Categorie uneCateg = uneDAO.find(idCateg);
                Boolean check = uneDAO.delete(uneCateg);
                if (check == true)
                {
                    MessageBox.Show("Catégorie supprimée.");
                }
                else
                {
                    MessageBox.Show("Incident dans la suppression de la catégorie.");
                }
            }
            else
            {
                MessageBox.Show("Suppression annulée.");
            }
            cbAffCateg.DataSource = CategorieDAO.findAll();
            cbAffCateg.DisplayMember = "Infos";
            cbAffCateg.ValueMember = "Id";
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            if(tbAddCateg.Text != "")
            {
                int id = DAO<Categorie>.NumMax("Catégorie", "id");
                string libelle = tbAddCateg.Text;
                CategorieDAO uneCategDAO = new CategorieDAO();
                Categorie uneCateg = new Categorie(id, libelle);
                Boolean check = uneCategDAO.create(uneCateg);
                if (check == true)
                {
                    MessageBox.Show("Catégorie ajouté.");
                }
                else
                {
                    MessageBox.Show("Incident dans l'ajout de la catégorie.");
                }
            }
            cbAffCateg.DataSource = CategorieDAO.findAll();
            cbAffCateg.DisplayMember = "Infos";
            cbAffCateg.ValueMember = "Id";
        }

        private void btnModifCateg_Click(object sender, EventArgs e)
        {
            if(tbModifCateg.Text != "")
            {
                int id = (int)cbAffCateg.SelectedValue;
                string libelle = tbModifCateg.Text;
                CategorieDAO uneCategDAO = new CategorieDAO();
                Categorie uneCateg = uneCategDAO.find(id);
                uneCateg.setLibelle(libelle);
                Boolean check = uneCategDAO.update(uneCateg);
                if (check == true)
                {
                    MessageBox.Show("Catégorie modifié.");
                }
                else
                {
                    MessageBox.Show("Incident dans la modification de la catégorie.");
                }
            }
            cbAffCateg.DataSource = CategorieDAO.findAll();
            cbAffCateg.DisplayMember = "Infos";
            cbAffCateg.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCategJouet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dGVJouets.Rows.Clear();
            List<Jouet> lesJouets = new List<Jouet>();
            CategorieDAO uneCategDAO = new CategorieDAO();
            Categorie uneCateg = uneCategDAO.find((int)cbCategJouet.SelectedValue);
            try { lesJouets = JouetDAO.findByCateg(uneCateg); }
            catch { MessageBox.Show("Problème avec la fonction pour trouver les jouets."); }
            try
            {
                Int32 i = 0;
                foreach (Jouet j in lesJouets)
                {
                    dGVJouets.Rows.Insert(i, j.getLibelle());
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Impossible d'afficher les jouets des enfants");
            }
        }

        private void dGVJouets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
