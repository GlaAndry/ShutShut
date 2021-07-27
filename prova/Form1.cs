using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShutShut.Utils;

namespace prova
{ 
    public partial class Form1 : Form
    {

        DateTime date;
        DateTime datetimepick;

        int min, hour;

        public Form1()
        {
            InitializeComponent();
        }

        /**
         * Annulla lo shutdown corrente se esiste.
         * */

        private void button2_Click(object sender, EventArgs e)
        {
            //inserisco il comando
            string command = "/C shutdown -a";
            System.Diagnostics.Process.Start("CMD.exe", command);
            //System.Diagnostics.Process process = new System.Diagnostics.Process();
            //System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = command;
            //process.StartInfo = startInfo;
            //process.Start();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /**
         * Accetto all'interno delle textbox solamente valori decimali
         * che ne indicano il valore di MINUTI */
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /**
         * Accetto all'interno delle textbox solamente valori decimali
         * che ne indicano il valore di ORE */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /**
         * Imposta il valore di Shutdown andando inizialmente
         * a calcolare la differenza di tempo (delta) e 
         * successivamente andando a richiamare il comando da CMD.
         * */
        private void button1_Click(object sender, EventArgs e)
        {
            
            date = DateTime.Now;
            datetimepick = dateTimePicker1.Value;

            //determino i secondi attuali di differenza
            int deltaT = new Utility().determineDelta(date, datetimepick);

            //aggiungo i valori di ore e minuti.
            min = int.Parse(textBox2.Text);
            hour = int.Parse(textBox1.Text);
           
            //ricavo la differenza aggiornata.
            deltaT = deltaT + (min * 60) + (hour * 60 * 60);

            //inserisco il comando e lo eseguo da CMD
            string command = "/C shutdown -s -t " + deltaT;
            System.Diagnostics.Process.Start("CMD.exe", command);

        }

    }
}
