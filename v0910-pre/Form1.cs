﻿using System;
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
        string[] labelTexts = new string[10];
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                vx[i] = rand.Next(-15, 16);
                vy[i] = rand.Next(-15, 16);

                labelTexts[i] = "☆";

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                labels[i].Font = label1.Font;
                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
                Controls.Add(labels[i]);

                if (rand.NextDouble() < 0.5)
                {
                    string t = labels[i].Text;
                    labels[i].Text = labelTexts[i];
                    labelTexts[i] = t;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                string temp = labels[i].Text;
                labels[i].Text = labelTexts[i];
                labelTexts[i] = temp;

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

                Point mp = PointToClient(MousePosition);
                if (    (mp.X >= labels[i].Left)
                    &&  (mp.X < labels[i].Right)
                    &&  (mp.Y >= labels[i].Top)
                    &&  (mp.Y < labels[i].Bottom)
                    )
                {
                    labels[i].Visible = false;
                }
            }
        }
    }
}
