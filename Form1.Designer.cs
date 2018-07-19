namespace StressTest
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numberStations = new System.Windows.Forms.Label();
            this.getResults = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "30";
            // 
            // numberStations
            // 
            this.numberStations.AutoSize = true;
            this.numberStations.Location = new System.Drawing.Point(34, 53);
            this.numberStations.Name = "numberStations";
            this.numberStations.Size = new System.Drawing.Size(95, 13);
            this.numberStations.TabIndex = 2;
            this.numberStations.Text = "Number of stations";
            // 
            // getResults
            // 
            this.getResults.Location = new System.Drawing.Point(230, 116);
            this.getResults.Name = "getResults";
            this.getResults.Size = new System.Drawing.Size(75, 23);
            this.getResults.TabIndex = 3;
            this.getResults.Text = "Get Results";
            this.getResults.UseVisualStyleBackColor = true;
            this.getResults.Visible = false;
            this.getResults.Click += new System.EventHandler(this.getResults_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 261);
            this.Controls.Add(this.getResults);
            this.Controls.Add(this.numberStations);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label numberStations;
        private System.Windows.Forms.Button getResults;
    }
}

