using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        private Color selectedColor = Color.Black;
        private List<Figure> shapes = new List<Figure>();
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            // Завдання 1
            buttonInfo.Click += buttonInfo_Click;
            buttonExit.MouseEnter += buttonExit_MouseEnter;

            // Завдання 2
            buttonOpen.Click += buttonOpen_Click;
            buttonSave.Click += buttonSave_Click;

            // Завдання 3
            buttonColor.Click += buttonColor_Click;
            buttonAdd.Click += buttonAdd_Click;
            buttonClearShapes.Click += buttonClearShapes_Click;
            pictureBox2.Paint += pictureBox2_Paint;

            // Комбобокс типів фігур
            comboBoxType.Items.AddRange(new string[] { "Коло", "Квадрат", "Прямокутник з текстом" });
            comboBoxType.SelectedIndex = 0;
        }

        // === Завдання 1 ===
        private void buttonInfo_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"X: {this.Location.X}, Y: {this.Location.Y}";
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            int newX = rnd.Next(0, this.ClientSize.Width - buttonExit.Width);
            int newY = rnd.Next(0, this.ClientSize.Height - buttonExit.Height);
            buttonExit.Location = new Point(newX, newY);
        }

        // === Завдання 2 ===
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Зображення (*.jpg; *.png; *.bmp)|*.jpg;*.png;*.bmp";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openDialog.FileName);
            }
        }

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

        // === Завдання 3 ===
        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            int x = rnd.Next(0, pictureBox2.Width - size);
            int y = rnd.Next(0, pictureBox2.Height - size);
            string type = comboBoxType.SelectedItem.ToString();
            string text = textBoxText.Text;

            Figure newFigure;

            switch (type)
            {
                case "Коло":
                    newFigure = new Circle(x, y, size, selectedColor);
                    break;
                case "Квадрат":
                    newFigure = new Square(x, y, size, selectedColor);
                    break;
                case "Прямокутник з текстом":
                    newFigure = new TextRectangle(x, y, size * 2, size, selectedColor, text);
                    break;
                default:
                    return;
            }

            shapes.Add(newFigure);
            pictureBox2.Invalidate(); // перемалювати
        }

        private void buttonClearShapes_Click(object sender, EventArgs e)
        {
            shapes.Clear();
            pictureBox2.Invalidate();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }

    // === Абстрактний базовий клас ===
    public abstract class Figure
    {
        public int X, Y;
        public Color Color;

        protected Figure(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }

        public abstract void Draw(Graphics g);
    }

    public class Circle : Figure
    {
        public int Radius;

        public Circle(int x, int y, int radius, Color color) : base(x, y, color)
        {
            Radius = radius;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, X, Y, Radius, Radius);
            }
        }
    }

    public class Square : Figure
    {
        public int Size;

        public Square(int x, int y, int size, Color color) : base(x, y, color)
        {
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillRectangle(brush, X, Y, Size, Size);
            }
        }
    }

    public class TextRectangle : Figure
    {
        public int Width, Height;
        public string Text;

        public TextRectangle(int x, int y, int width, int height, Color color, string text) : base(x, y, color)
        {
            Width = width;
            Height = height;
            Text = text;
        }

        public override void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
                using (Font font = new Font("Arial", 10))
                using (Brush textBrush = new SolidBrush(Color.Black))
                {
                    StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString(Text, font, textBrush, new Rectangle(X, Y, Width, Height), sf);
                }
            }
        }
    }
}
