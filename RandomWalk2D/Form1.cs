using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomWalk2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();

            Graphics gg = CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            SolidBrush sb1 = new SolidBrush(Color.Blue);
            SolidBrush sb2 = new SolidBrush(Color.DarkGreen);

            int nsteps = int.Parse(textBox1.Text);
            int nwalks = int.Parse(textBox2.Text);

            //Declearing 2D Array
            float[] r2ave = new float[nsteps];
            float y, x, delx = 10, dely = 10;  // x & y = dispalcement , delx & dely = step size
            
            Random obj = new Random();
            double prob;

            //Strating the Walk
            for (int w = 0; w < nwalks; w++)
            {
                x = 0;
                y = 0;

                for (int s = 0; s < nsteps; s++)
                {
                    prob = obj.NextDouble();
                    if (prob < 0.25)
                    {
                        x = x + delx;
                    }
                    if (prob >= 0.25 && prob < 0.5)
                    {
                        x = x - delx;
                    }
                    if (prob >= 0.5 && prob < 0.75)
                    {
                        y = y + dely;
                    }
                    if (prob >= 0.75)
                    {
                        y = y - dely;
                    }

                    gg.FillEllipse(sb2, 600 + x, 300 - y, 4, 4);
                    

                    r2ave[s] = r2ave[s] + x * x + y * y;
                    //gg.FillEllipse(sb2, 400 + x, 400 - y, 10, 10);
                    Thread.Sleep(10);

                    //this.Refresh();
                    //After each step the form will refresh

                } // Ending of Single Walk
            } // Ending of All Walks

            //this.Refresh();
            //After walks the form will refresh

            // Computing the Mean Sqaure r
            for (int s = 0; s < nsteps; s++)
            {
                r2ave[s] = r2ave[s] / nwalks;
                // By this we will get averag displacement of every walkers

                gg.FillEllipse(sb, 100 + s * 10, 600 - r2ave[s], 4, 4);
                gg.FillEllipse(sb1, 100 + s * 10, 600 - (float)Math.Sqrt(r2ave[s]), 4, 4);
            }
        }
    }
}
