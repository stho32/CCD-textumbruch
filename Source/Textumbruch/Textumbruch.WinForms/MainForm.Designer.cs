namespace Textumbruch.WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VorherLabel = new System.Windows.Forms.Label();
            this.NachherLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VorherTextbox = new System.Windows.Forms.TextBox();
            this.NachherTextbox = new System.Windows.Forms.TextBox();
            this.BreiteInZeichenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.UmbrechenButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BreiteInZeichenNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // VorherLabel
            // 
            this.VorherLabel.AutoSize = true;
            this.VorherLabel.Location = new System.Drawing.Point(12, 9);
            this.VorherLabel.Name = "VorherLabel";
            this.VorherLabel.Size = new System.Drawing.Size(44, 15);
            this.VorherLabel.TabIndex = 0;
            this.VorherLabel.Text = "Vorher:";
            // 
            // NachherLabel
            // 
            this.NachherLabel.AutoSize = true;
            this.NachherLabel.Location = new System.Drawing.Point(12, 182);
            this.NachherLabel.Name = "NachherLabel";
            this.NachherLabel.Size = new System.Drawing.Size(55, 15);
            this.NachherLabel.TabIndex = 1;
            this.NachherLabel.Text = "Nachher:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Breite in Zeichen:";
            // 
            // VorherTextbox
            // 
            this.VorherTextbox.Location = new System.Drawing.Point(12, 27);
            this.VorherTextbox.Multiline = true;
            this.VorherTextbox.Name = "VorherTextbox";
            this.VorherTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.VorherTextbox.Size = new System.Drawing.Size(532, 152);
            this.VorherTextbox.TabIndex = 3;
            // 
            // NachherTextbox
            // 
            this.NachherTextbox.Location = new System.Drawing.Point(12, 200);
            this.NachherTextbox.Multiline = true;
            this.NachherTextbox.Name = "NachherTextbox";
            this.NachherTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.NachherTextbox.Size = new System.Drawing.Size(532, 155);
            this.NachherTextbox.TabIndex = 4;
            // 
            // BreiteInZeichenNumericUpDown
            // 
            this.BreiteInZeichenNumericUpDown.Location = new System.Drawing.Point(116, 367);
            this.BreiteInZeichenNumericUpDown.Name = "BreiteInZeichenNumericUpDown";
            this.BreiteInZeichenNumericUpDown.Size = new System.Drawing.Size(120, 23);
            this.BreiteInZeichenNumericUpDown.TabIndex = 5;
            this.BreiteInZeichenNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // UmbrechenButton
            // 
            this.UmbrechenButton.Location = new System.Drawing.Point(456, 365);
            this.UmbrechenButton.Name = "UmbrechenButton";
            this.UmbrechenButton.Size = new System.Drawing.Size(88, 23);
            this.UmbrechenButton.TabIndex = 6;
            this.UmbrechenButton.Text = "Umbrechen";
            this.UmbrechenButton.UseVisualStyleBackColor = true;
            this.UmbrechenButton.Click += new System.EventHandler(this.UmbrechenButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 402);
            this.Controls.Add(this.UmbrechenButton);
            this.Controls.Add(this.BreiteInZeichenNumericUpDown);
            this.Controls.Add(this.NachherTextbox);
            this.Controls.Add(this.VorherTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NachherLabel);
            this.Controls.Add(this.VorherLabel);
            this.Name = "MainForm";
            this.Text = "Textumbruch";
            ((System.ComponentModel.ISupportInitialize)(this.BreiteInZeichenNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label VorherLabel;
        private Label NachherLabel;
        private Label label3;
        private TextBox VorherTextbox;
        private TextBox NachherTextbox;
        private NumericUpDown BreiteInZeichenNumericUpDown;
        private Button UmbrechenButton;
    }
}