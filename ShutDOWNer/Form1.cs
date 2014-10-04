using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShutDOWNer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int hm;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 23; i++)
            {
                hours.Items.Add(i);
            }

            for (int i = 1; i <= 59; i++)
            {
                minutes.Items.Add(i);
            }

            hours.Text = "0";
            minutes.Text = "1";
            variant.Text = "Выключить";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int h, m;
            h = Convert.ToInt32(hours.Text);
            m = Convert.ToInt32(minutes.Text);
            hm = (h*60+m)*60;

            if (hm < 1) return;

            label4.Text = hm.ToString();
            progressBar1.Maximum = hm;
            
            if (timer1.Enabled != true)
            {
                button1.Text = "СТОП";
                timer1.Enabled = true;
            }
            else
            {
                button1.Text = "ЗАПУСК";
                timer1.Enabled = false;
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(hm>0) hm = hm - 1;
            label4.Text = hm.ToString();
            progressBar1.Value = hm;

            if (hm == 0)
            {
                if (variant.Text == "Выключить")
                {
                    timer1.Enabled = false;
                    System.Diagnostics.Process.Start("Shutdown", "-s -t 15");
                }

                if (variant.Text == "Спящий режим")
                {
                    timer1.Enabled = false;
                    System.Diagnostics.Process.Start("rundll32.exe", "powrprof.dll,SetSuspendState");
                }
            }
        }

    }
}
