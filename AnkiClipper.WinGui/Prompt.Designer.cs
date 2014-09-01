namespace AnkiClipper
{
    partial class Prompt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public string sAnswer;
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
            this.Description = new System.Windows.Forms.Label();
            this.Answer = new System.Windows.Forms.TextBox();
            this.Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(12, 9);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(294, 13);
            this.Description.TabIndex = 0;
            this.Description.Text = "Please enter a Title (and optionally Tags using the @ symbol)";
            this.Description.Click += new System.EventHandler(this.Description_Click);
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(12, 26);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(311, 20);
            this.Answer.TabIndex = 1;
            this.Answer.TextChanged += new System.EventHandler(this.Answer_TextChanged);
            this.Answer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Answer_KeyPress);
            // 
            // Ok
            // 
            this.Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Ok.Location = new System.Drawing.Point(329, 23);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(75, 23);
            this.Ok.TabIndex = 2;
            this.Ok.Text = "Continue";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 56);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.Description);
            this.Name = "Prompt";
            this.Text = "Anki Card Title and Tags";
            this.Load += new System.EventHandler(this.Prompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.Button Ok;
    }
}