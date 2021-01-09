namespace PPEJouetTV
{
    partial class FormBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.lblLog = new System.Windows.Forms.Label();
            this.lblPasswd = new System.Windows.Forms.Label();
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.nbId = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nbId)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Segoe Script", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLog.Location = new System.Drawing.Point(276, 112);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(90, 34);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "Login :";
            this.lblLog.Click += new System.EventHandler(this.lblLog_Click);
            // 
            // lblPasswd
            // 
            this.lblPasswd.AutoSize = true;
            this.lblPasswd.Font = new System.Drawing.Font("Segoe Script", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswd.Location = new System.Drawing.Point(247, 193);
            this.lblPasswd.Name = "lblPasswd";
            this.lblPasswd.Size = new System.Drawing.Size(139, 28);
            this.lblPasswd.TabIndex = 1;
            this.lblPasswd.Text = "Mot de Passe :";
            this.lblPasswd.Click += new System.EventHandler(this.lblPasswd_Click);
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.Location = new System.Drawing.Point(252, 239);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.Size = new System.Drawing.Size(128, 20);
            this.textBoxPasswd.TabIndex = 3;
            this.textBoxPasswd.UseSystemPasswordChar = true;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(203, 284);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(84, 25);
            this.btnQuitter.TabIndex = 4;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = true;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Segoe Script", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(340, 284);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(84, 25);
            this.btnValider.TabIndex = 5;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // nbId
            // 
            this.nbId.Location = new System.Drawing.Point(252, 159);
            this.nbId.Name = "nbId";
            this.nbId.Size = new System.Drawing.Size(128, 20);
            this.nbId.TabIndex = 6;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(597, 412);
            this.Controls.Add(this.nbId);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.textBoxPasswd);
            this.Controls.Add(this.lblPasswd);
            this.Controls.Add(this.lblLog);
            this.Name = "FormBase";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nbId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Label lblPasswd;
        private System.Windows.Forms.TextBox textBoxPasswd;
        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.NumericUpDown nbId;
    }
}

