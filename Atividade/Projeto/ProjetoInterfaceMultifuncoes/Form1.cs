using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoInterfaceMultifuncoes
{
    public partial class Form1 : Form
    {
        private StringBuilder bufferRecebido = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
            timerCOM.Interval = 2000;
            timerCOM.Start();
            picBoxLED.Tag = "Desligado";
            picBoxLED.Image = Image.FromFile("");
            picBoxLED.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                bufferRecebido.Append(serialPort1.ReadExisting());

                if (bufferRecebido.ToString().Contains("\n"))
                {
                    this.Invoke((MethodInvoker)trataDadosRecebidos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao receber dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void atualizaListaCOMs()
        {
            comboBox1.Items.Clear();
            string[] portas = SerialPort.GetPortNames();

            if (portas.Length == 0)
            {
                comboBox1.Items.Add("Nenhuma porta encontrada");
                comboBox1.SelectedIndex = 0;
                return;
            }

            foreach (string porta in portas)
                comboBox1.Items.Add(porta);
        }

        private void trataDadosRecebidos()
        {
            try
            {
                string[] linhas = bufferRecebido.ToString().Split('\n');
                bufferRecebido.Clear();

                if (linhas.Length > 0)
                {
                    bufferRecebido.Append(linhas[linhas.Length - 1]);
                }

                // Agora dividimos os dados usando a vírgula como delimitador
                string dadosRecebidos = linhas[0].Trim();
                string[] dados = dadosRecebidos.Split(',');

                if (dados.Length == 3)
                {
                    double temperatura = double.Parse(dados[0]);
                    double tensaoA0 = double.Parse(dados[2]);

                    // Atualiza os rótulos na interface
                    lblSensorTemp.Text = temperatura.ToString("0.00") + " °C";
                    lblPotenciometro.Text = tensaoA0.ToString("0.00") + " V";
                }
                else
                {
                    MessageBox.Show("Dados recebidos estão com formato incorreto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void conectarSerial()
        {
            if (comboBox1.SelectedItem == null || comboBox1.SelectedItem.ToString() == "Nenhuma porta encontrada")
            {
                MessageBox.Show("Selecione uma porta COM válida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;

                serialPort1.Open();
                btnConectar.Text = "Desconectar";
                btnConectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desconectarSerial()
        {
            try
            {
                serialPort1.Close();
                comboBox1.Enabled = true;
                btnConectar.Text = "Conectar";
                btnConectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desconectar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                desconectarSerial();
            }
            else
            {
                conectarSerial();
            }
        }

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void picBoxLED_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (picBoxLED.Tag.ToString() == "Desligado")
                    {
                        serialPort1.Write("D\n");
                        picBoxLED.Tag = "Ligado";
                        picBoxLED.Image = Image.FromFile("");
                        picBoxLED.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        serialPort1.Write("L\n");
                        picBoxLED.Tag = "Desligado";
                        picBoxLED.Image = Image.FromFile("");
                        picBoxLED.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao enviar comando: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
