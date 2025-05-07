namespace Lab7CSharp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBox1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(30, 30);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(100, 30);
            this.buttonInfo.Text = "Інформація";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(150, 30);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(100, 30);
            this.buttonExit.Text = "Вихід";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 80);
            this.textBox1.Size = new System.Drawing.Size(220, 20);
            this.textBox1.Name = "textBox1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Lab7";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
