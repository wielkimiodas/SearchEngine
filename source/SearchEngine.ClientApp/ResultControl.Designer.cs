namespace SearchEngine.ClientApp
{
    sealed partial class ResultControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btShowOrigin = new System.Windows.Forms.Button();
            this.btStemmed = new System.Windows.Forms.Button();
            this.lblSimilarity = new System.Windows.Forms.Label();
            this.lblSimValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Adobe Fangsong Std R", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(383, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "<Title>";
            // 
            // btShowOrigin
            // 
            this.btShowOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btShowOrigin.Location = new System.Drawing.Point(308, 83);
            this.btShowOrigin.Name = "btShowOrigin";
            this.btShowOrigin.Size = new System.Drawing.Size(75, 23);
            this.btShowOrigin.TabIndex = 1;
            this.btShowOrigin.Text = "Origin";
            this.btShowOrigin.UseVisualStyleBackColor = true;
            this.btShowOrigin.Click += new System.EventHandler(this.btShowOrigin_Click);
            // 
            // btStemmed
            // 
            this.btStemmed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btStemmed.Location = new System.Drawing.Point(227, 83);
            this.btStemmed.Name = "btStemmed";
            this.btStemmed.Size = new System.Drawing.Size(75, 23);
            this.btStemmed.TabIndex = 2;
            this.btStemmed.Text = "Stemmed";
            this.btStemmed.UseVisualStyleBackColor = true;
            this.btStemmed.Click += new System.EventHandler(this.btStemmed_Click);
            // 
            // lblSimilarity
            // 
            this.lblSimilarity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSimilarity.AutoSize = true;
            this.lblSimilarity.Font = new System.Drawing.Font("Adobe Fangsong Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSimilarity.Location = new System.Drawing.Point(3, 83);
            this.lblSimilarity.Name = "lblSimilarity";
            this.lblSimilarity.Size = new System.Drawing.Size(81, 20);
            this.lblSimilarity.TabIndex = 3;
            this.lblSimilarity.Text = "Similarity: ";
            // 
            // lblSimValue
            // 
            this.lblSimValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSimValue.AutoSize = true;
            this.lblSimValue.Font = new System.Drawing.Font("Adobe Fangsong Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSimValue.Location = new System.Drawing.Point(90, 83);
            this.lblSimValue.Name = "lblSimValue";
            this.lblSimValue.Size = new System.Drawing.Size(62, 20);
            this.lblSimValue.TabIndex = 4;
            this.lblSimValue.Text = "<value>";
            // 
            // ResultControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lblSimValue);
            this.Controls.Add(this.lblSimilarity);
            this.Controls.Add(this.btStemmed);
            this.Controls.Add(this.btShowOrigin);
            this.Controls.Add(this.lblTitle);
            this.Name = "ResultControl";
            this.Size = new System.Drawing.Size(383, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btShowOrigin;
        private System.Windows.Forms.Button btStemmed;
        private System.Windows.Forms.Label lblSimilarity;
        private System.Windows.Forms.Label lblSimValue;
    }
}
