using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Atividade3
{
    public partial class Form1 : Form
    {
        private bool continuarLoop = true;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@"C:\Imagens\base.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\base.bmp");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToLongDateString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult bc;
            MessageBoxButtons bot = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.Asterisk;
            MessageBoxDefaultButton bd = MessageBoxDefaultButton.Button1;

            button4.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            continuarLoop = false;
            pictureBox1.Image = Image.FromFile(@"C:\Imagens\amarelos.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\amarelos.bmp");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            bc = MessageBox.Show("EMERGÊNCIA ACIONADO", "Informação", bot, icon, bd);
            await Task.Delay(5000);


            pictureBox1.Image = Image.FromFile(@"C:\Imagens\base.bmp");
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\base.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            button4.Enabled = true;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.policiamilitar.sp.gov.br/");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.corpodebombeiros.sp.gov.br/#/");
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            DialogResult bc;
            MessageBoxButtons bot = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Asterisk;
            MessageBoxDefaultButton bd = MessageBoxDefaultButton.Button1;

            bc = MessageBox.Show("Deseja iniciar?", "Informação", bot, icon, bd);

            if (bc == DialogResult.Yes)
            {
                timer2.Enabled = true;
                pictureBox2.Image = Image.FromFile(@"C:\Imagens\verdes.bmp");
                continuarLoop = true;
                while (continuarLoop)
                {
                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\vermelhos.bmp");
                        await Task.Delay(3000);
                    }

                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\verdes.bmp");
                        await Task.Delay(2000);
                    }

                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\amarelos.bmp");
                        await Task.Delay(1000);
                    }

                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\vermelhos.bmp");
                        await Task.Delay(3000);
                    }

                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\verdes.bmp");
                        await Task.Delay(2000);
                    }

                    if (continuarLoop)
                    {
                        pictureBox1.Image = Image.FromFile(@"C:\Imagens\amarelos.bmp");
                        await Task.Delay(1000);
                    }
                 }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Imagens\base.bmp");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            continuarLoop = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\base.bmp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult bc;
            MessageBoxButtons bot = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Asterisk;
            MessageBoxDefaultButton bd = MessageBoxDefaultButton.Button3;

            bc = MessageBox.Show("Deseja Sair?", "Informação", bot, icon, bd);

            if (bc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\amarelos.bmp");
            timer2.Enabled = false;
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\vermelhos.bmp");
            timer3.Enabled = false;
            timer4.Enabled = true;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\Imagens\verdes.bmp");
            timer4.Enabled = false;
            timer2.Enabled = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
