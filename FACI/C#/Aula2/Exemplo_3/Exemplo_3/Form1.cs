using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exemplo_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image=Image.FromFile("c:\\Imagens\\Emoji.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        //Botão LIGA
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("c:\\Imagens\\emojikk.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("c:\\Imagens\\emojigg.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
