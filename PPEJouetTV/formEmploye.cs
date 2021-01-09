using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PPEJouetTV
{
    public partial class formEmploye : Form
    {
        private Int32 id;
        public formEmploye(Int32 pId)
        {
            InitializeComponent();
            id = pId;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
                    }

        private void formEmploye_Load(object sender, EventArgs e)
        {
            cbCateg.DisplayMember = "Infos";
            cbCateg.ValueMember = "Id";
            cbCateg.DataSource = CategorieDAO.findAll();

            cbAEnfants.DisplayMember = "Infos";
            cbAEnfants.ValueMember = "Id";
            cbAEnfants.DataSource = EnfantDAO.findByEmploye(id);

            List<Cadeau> lesCadeaux = new List<Cadeau>();
            try { lesCadeaux = CadeauDAO.findEnfants(id); }
            catch { MessageBox.Show("Problème avec la fonction pour trouver les jouets."); }
           
            try
            {
                Int32 i = 0;
                foreach(Cadeau leCadeau in lesCadeaux)
                {
                    dataGridView1.Rows.Insert(i, leCadeau.getEnfant().getPrenom(), leCadeau.getJouet().getLibelle(), leCadeau.getDate());
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Impossible d'afficher les jouets des enfants");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void cbAEnfants_SelectedIndexChanged(object sender, EventArgs e)
        {
            dGVJouet.Rows.Clear();
            //Enfant
            Int32 idEnfant = (int)cbAEnfants.SelectedValue;
            Enfant unEnfant;
            EnfantDAO unEnfantDAO = new EnfantDAO();
            try
            {
                unEnfant = unEnfantDAO.find(idEnfant);
            }
            catch (Exception ex)
            {
                unEnfant = null;
                throw new Exception("Oups: " + ex);
                
            }
            Int32 idCateg = (Int32)cbCateg.SelectedValue;
            TrancheAge uneTranche = null;
            CategorieDAO uneCategDAO = new CategorieDAO();
            Categorie uneCateg;
            try
            {
                uneCateg = uneCategDAO.find(idCateg);
            }
            catch
            {
                MessageBox.Show("catégorie inexistante");
                uneCateg = null;
            }

            Int32 ageValeur = unEnfant.getAge();

            if (ageValeur >= 1 && ageValeur <= 2)
            {
                uneTranche = new TrancheAge(1, 1, 2);
            }
            else if (ageValeur >= 3 && ageValeur <= 5)
            {
                uneTranche = new TrancheAge(2, 3, 5);
            }
            else if (ageValeur >= 6 && ageValeur <= 10)
            {
                uneTranche = new TrancheAge(3, 6, 10);
            }
            else if (ageValeur >= 11 && ageValeur <= 13)
            {
                uneTranche = new TrancheAge(4, 11, 13);
            }
            else if (ageValeur >= 14 && ageValeur <= 17)
            {
                uneTranche = new TrancheAge(5, 14, 17);
            }
            else
            {
                MessageBox.Show("Cet enfant est trop âgé");
            }

            //Categorie uneCateg = new Categorie(1, "Action");

            if (uneTranche != null)
            {
                List<Jouet> lesJouets = JouetDAO.findByTrancheCateg(uneTranche, uneCateg);

                Int32 i = 0;
                foreach (Jouet leJouet in lesJouets)
                {
                    dGVJouet.Rows.Insert(i, leJouet.getLibelle(), uneCateg.getLibelle());
                    i++;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbCateg_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dGVJouet.Rows.Clear();
            //Enfant
            Int32 idEnfant = (Int32)cbAEnfants.SelectedValue;
            Enfant unEnfant;
            EnfantDAO unEnfantDAO = new EnfantDAO();
            try {
                unEnfant = unEnfantDAO.find(idEnfant);
            }
            catch(Exception ex)
            {
                unEnfant = null;
                throw new Exception("Oups: " + ex);
            }
            Int32 idCateg = (Int32)cbCateg.SelectedValue;
            TrancheAge uneTranche = null;
            CategorieDAO uneCategDAO = new CategorieDAO();
            Categorie uneCateg;
            try
            {
                uneCateg = uneCategDAO.find(idCateg);
            }
            catch
            {
                MessageBox.Show("catégorie inexistante");
                uneCateg = null;
            }
            
            Int32 ageValeur = unEnfant.getAge();

            if (ageValeur >= 1 && ageValeur <= 2)
            {
                uneTranche = new TrancheAge(1, 1, 2);
            }
            else if (ageValeur >= 3 && ageValeur <= 5)
            {
                uneTranche = new TrancheAge(2, 3, 5);
            }
            else if (ageValeur >= 6 && ageValeur <= 10)
            {
                uneTranche = new TrancheAge(3, 6, 10);
            }
            else if (ageValeur >= 11 && ageValeur <= 13)
            {
                uneTranche = new TrancheAge(4, 11, 13);
            }
            else if (ageValeur >= 14 && ageValeur <= 17)
            {
                uneTranche = new TrancheAge(5, 14, 17);
            }
            else
            {
                MessageBox.Show("Cet enfant est trop âgé");
            }

            //Categorie uneCateg = new Categorie(1, "Action");

            if (uneTranche != null)
            {
                List<Jouet> lesJouets = JouetDAO.findByTrancheCateg(uneTranche, uneCateg);

                Int32 i = 0;
                foreach (Jouet leJouet in lesJouets)
                {
                    dGVJouet.Rows.Insert(i, leJouet.getLibelle(), uneCateg.getLibelle());
                    i++;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String nom = (string)dGVJouet.CurrentRow.Cells["Nom"].Value;
            Jouet unJouet = JouetDAO.findByNom(nom);

            DateTime localDate = DateTime.Now;

            Int32 idEnfant = (int)cbAEnfants.SelectedValue;
            EnfantDAO unEnfantDAO = new EnfantDAO();
            Enfant unEnfant = unEnfantDAO.find(idEnfant);

            Cadeau unCadeau = new Cadeau(unEnfant, unJouet, localDate);
            CadeauDAO unCadeauDAO = new CadeauDAO();

            if (unCadeauDAO.findByEnfant(idEnfant) == null)
            {
                unCadeauDAO.create(unCadeau);
                MessageBox.Show("Cadeau ajouté...");
            }
            else
            {
                unCadeauDAO.update(unCadeau);
                MessageBox.Show("Cadeau modifié...");
            }

            dataGridView1.Rows.Clear();


            //Affichage cadeaux
            List<Cadeau> lesCadeaux = new List<Cadeau>();
            try { lesCadeaux = CadeauDAO.findEnfants(id); }
            catch { MessageBox.Show("Problème avec la fonction trouver les jouets."); }

            try
            {
                Int32 i = 0;
                foreach (Cadeau leCadeau in lesCadeaux)
                {
                    dataGridView1.Rows.Insert(i, leCadeau.getEnfant().getPrenom(), leCadeau.getJouet().getLibelle(), leCadeau.getDate());
                    i++;
                }
            }
            catch
            {
                MessageBox.Show("Impossible d'afficher les jouets des enfants");
            }
        }

        private void dGVJouet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
