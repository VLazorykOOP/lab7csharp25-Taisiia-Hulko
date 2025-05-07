using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"X: {this.Location.X}, Y: {this.Location.Y}";
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int newX = rnd.Next(0, this.ClientSize.Width - buttonExit.Width);
            int newY = rnd.Next(0, this.ClientSize.Height - buttonExit.Height);
            buttonExit.Location = new Point(newX, newY);
        }
    }
}
