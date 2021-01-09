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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (nbId.Value != 0 && textBoxPasswd.Text != "")
            {
                Int32 id = (int)nbId.Value;
                String mdp = textBoxPasswd.Text;
                if (Utilisateur.verifUtilisateur(id, mdp) == false)
                {
                    MessageBox.Show("Login ou Mot de passe incorrect.");
                }
                else if (Utilisateur.verifUtilisateur(id, mdp) == true)
                {
                    UtilisateurDAO unU = new UtilisateurDAO();
                    if (unU.find(id).getTypeU() == 1)
                    {
                        formResponsable formTest = new formResponsable();
                        formTest.ShowDialog();
                    }
                    else if (unU.find(id).getTypeU() == 2)
                    {
                        formEmploye formTest = new formEmploye(id);
                        formTest.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Type utilisateur inconnu ...");
                    }

                }
                textBoxPasswd.Clear();
            }
            else
            {
                MessageBox.Show("Veuillez renseigner votre login et votre mot de passe.");
            }
        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }

        private void lblPasswd_Click(object sender, EventArgs e)
        {

        }
    }
}
