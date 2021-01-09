namespace PPEJouetTV
{
    partial class formEmploye
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEmploye));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbCateg = new System.Windows.Forms.ComboBox();
            this.dGVJouet = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categorie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAEnfants = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Enfant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jouet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVJouet)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(9, 9);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 394);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage2.BackgroundImage")));
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.cbCateg);
            this.tabPage2.Controls.Add(this.dGVJouet);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.cbAEnfants);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(571, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Choisir Cadeau";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cbCateg
            // 
            this.cbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCateg.FormattingEnabled = true;
            this.cbCateg.Location = new System.Drawing.Point(66, 156);
            this.cbCateg.Name = "cbCateg";
            this.cbCateg.Size = new System.Drawing.Size(121, 25);
            this.cbCateg.TabIndex = 8;
            this.cbCateg.SelectedIndexChanged += new System.EventHandler(this.cbCateg_SelectedIndexChanged_1);
            // 
            // dGVJouet
            // 
            this.dGVJouet.AllowUserToAddRows = false;
            this.dGVJouet.AllowUserToDeleteRows = false;
            this.dGVJouet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVJouet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVJouet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Categorie});
            this.dGVJouet.Location = new System.Drawing.Point(64, 199);
            this.dGVJouet.MultiSelect = false;
            this.dGVJouet.Name = "dGVJouet";
            this.dGVJouet.ReadOnly = true;
            this.dGVJouet.RowHeadersVisible = false;
            this.dGVJouet.Size = new System.Drawing.Size(240, 150);
            this.dGVJouet.TabIndex = 7;
            this.dGVJouet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVJouet_CellContentClick);
            // 
            // Nom
            // 
            this.Nom.FillWeight = 121.8274F;
            this.Nom.HeaderText = "Nom Jouet";
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            // 
            // Categorie
            // 
            this.Categorie.FillWeight = 78.17259F;
            this.Categorie.HeaderText = "Catégorie";
            this.Categorie.Name = "Categorie";
            this.Categorie.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(412, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 49);
            this.button1.TabIndex = 6;
            this.button1.Text = "Déconnexion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(412, 270);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(95, 43);
            this.button4.TabIndex = 5;
            this.button4.Text = "Valider";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Catégorie";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbAEnfants
            // 
            this.cbAEnfants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAEnfants.FormattingEnabled = true;
            this.cbAEnfants.Location = new System.Drawing.Point(64, 67);
            this.cbAEnfants.Name = "cbAEnfants";
            this.cbAEnfants.Size = new System.Drawing.Size(123, 25);
            this.cbAEnfants.TabIndex = 1;
            this.cbAEnfants.SelectedIndexChanged += new System.EventHandler(this.cbAEnfants_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Choisir votre enfant";
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabPage3.BackgroundImage")));
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(571, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Commandes Cadeaux";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enfant,
            this.Jouet,
            this.Date});
            this.dataGridView1.Location = new System.Drawing.Point(44, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(335, 279);
            this.dataGridView1.TabIndex = 8;
            // 
            // Enfant
            // 
            this.Enfant.HeaderText = "Enfant";
            this.Enfant.Name = "Enfant";
            this.Enfant.ReadOnly = true;
            // 
            // Jouet
            // 
            this.Jouet.HeaderText = "Jouet";
            this.Jouet.Name = "Jouet";
            this.Jouet.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(432, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "Déconnexion";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // formEmploye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(597, 412);
            this.Controls.Add(this.tabControl1);
            this.Name = "formEmploye";
            this.Text = "formEmploye";
            this.Load += new System.EventHandler(this.formEmploye_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVJouet)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAEnfants;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dGVJouet;
        private System.Windows.Forms.ComboBox cbCateg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categorie;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enfant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jouet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}