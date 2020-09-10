using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v0910_pre
{
    public partial class Form1 : Form
    {
        int[] vx = new int[10];
        int[] vy = new int[10];
        Label[] labels = new Label[10];
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                vx[i] = rand.Next(-15, 16);
                vy[i] = rand.Next(-15, 16);

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                labels[i].Font = label1.Font;
                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
                Controls.Add(labels[i]);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                else if (labels[i].Right > ClientSize.Width)
                {
                    vx[i] = -Math.Abs(vx[i]);
                }
                if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                else if (labels[i].Bottom > ClientSize.Height)
                {
                    vy[i] = -Math.Abs(vy[i]);
                }
            }
        }
    }
}
