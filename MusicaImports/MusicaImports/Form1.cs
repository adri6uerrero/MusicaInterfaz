using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls.RJControls;

namespace MusicaImports
{
    public partial class Form1 : Form
    {
        private int segundosTranscurridos = 0;  
        private int totalSegundos = 151;        

        public Form1()
        {
            InitializeComponent();
            label2.Font = new Font(label2.Font, FontStyle.Bold);
            label3.Font = new Font(label3.Font, FontStyle.Bold);

        }
        private void rjCircularPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tbDarkTheme_CheckedChanged_1(object sender, EventArgs e)
        {
            if (tbDarkTheme.Checked)
            {
                this.BackColor = Color.DimGray;
                label1.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.DimGray;
            }
        }

        private bool enEjecucion = false; 

        private void rjButton1_Click(object sender, EventArgs e)
        {
            if (enEjecucion)
            {
                timer1.Stop();
                enEjecucion = false;
            }
            else
            {
                timer1.Start();
                enEjecucion = true;
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (segundosTranscurridos < totalSegundos)
            {
                segundosTranscurridos++;
                rjProgressBar1.Value = segundosTranscurridos;

                rjProgressBar1.SymbolBefore = FormatearTiempo(segundosTranscurridos);
                rjProgressBar1.SymbolAfter = " / " + FormatearTiempo(totalSegundos);
            }
            else
            {
                timer1.Stop(); 
            }
        }


        private string FormatearTiempo(int segundos)
        {
            int minutos = segundos / 60;
            int segundosRestantes = segundos % 60;
            return $"{minutos:D2}:{segundosRestantes:D2}"; 
            rjProgressBar1.SymbolBefore = $"{FormatearTiempo(segundosTranscurridos)} ";
            rjProgressBar1.SymbolAfter = $" / {FormatearTiempo(totalSegundos)} ";

        }



        private void rjProgressBar1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int nuevoValor = (int)((double)me.X / rjProgressBar1.Width * totalSegundos);

            segundosTranscurridos = nuevoValor;
            rjProgressBar1.Value = nuevoValor;

            rjProgressBar1.SymbolBefore = FormatearTiempo(nuevoValor);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            rjProgressBar1.Minimum = 0;
            rjProgressBar1.Maximum = totalSegundos; 
            rjProgressBar1.ShowValue = TextPosition.Sliding; 
            rjProgressBar1.SymbolBefore = FormatearTiempo(0); 
            rjProgressBar1.SymbolAfter = " / " + FormatearTiempo(totalSegundos); 
        }

        private void rjButtonFw1_Click(object sender, EventArgs e)
        {
            rjProgressBar1.Value = 0;
            segundosTranscurridos = 0; 
        }

        private void rjButtonX1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
