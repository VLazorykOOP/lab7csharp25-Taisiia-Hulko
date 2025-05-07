using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Прив'язка подій (переконайся, що імена збігаються з Name у дизайнері)
            buttonInfo.Click += buttonInfo_Click;
            buttonExit.MouseEnter += buttonExit_MouseEnter;
            buttonOpen.Click += buttonOpen_Click;
            buttonSave.Click += buttonSave_Click;
        }

        // Завдання 1: кнопка "Інформація"
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"X: {this.Location.X}, Y: {this.Location.Y}";
        }

        // Завдання 1: кнопка "Вихід" рухається
        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int newX = rnd.Next(0, this.ClientSize.Width - buttonExit.Width);
            int newY = rnd.Next(0, this.ClientSize.Height - buttonExit.Height);
            buttonExit.Location = new Point(newX, newY);
        }

        // Завдання 2: кнопка "Відкрити"
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = @"C:\Users\mu qing\Desktop\uni\2nd_year\2\крос-платформне\lab7";
            openDialog.Filter = "Зображення (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Image original = Image.FromFile(openDialog.FileName);
                pictureBox1.Image = original;
            }
        }

        // Завдання 2: кнопка "Зберегти"
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap original = new Bitmap(pictureBox1.Image);
                original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Дзеркально по горизонталі

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PNG Image|*.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    original.Save(saveDialog.FileName);
                    MessageBox.Show("Зображення збережено успішно!");
                }
            }
            else
            {
                MessageBox.Show("Спочатку відкрий зображення.");
            }
        }
    }
}
