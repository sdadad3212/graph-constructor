using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        Font font = new Font("Verdana", 6);
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x=Convert.ToInt32(textBox1.Text);
            Bitmap bitmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            int[] arr = new int[x];
            int[] arr1 = new int[x];
            for (int i = 0; i < x; i++)
            {
              
                int r1 = rand.Next(0, pictureBox1.Width);
                int r2 = rand.Next(0, pictureBox1.Height);
                arr[i] = r1;
                arr1[i] = r2;
                g.DrawString((i).ToString(), font, Brushes.Black, r1, r2);
                g.DrawEllipse(Pens.Black,r1-10, r2-10, 20, 20);
            }
            for (int i = 0; i < textBox2.Lines.Length; i++)
            {
                int x1 = int.Parse(textBox2.Lines[i][0].ToString());
                int x2 = int.Parse(textBox2.Lines[i][2].ToString());
                g.DrawLine(Pens.Black, arr[x1], arr1[x1], arr[x2], arr1[x2]);
            }
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox2.Clear();
            textBox2.Text = fileText;
        }
    }
}
