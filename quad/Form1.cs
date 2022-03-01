using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace quad
{
    public partial class Form1 : Form
    {
        quadbrot qb = new quadbrot();
        public Form1()
        {
            InitializeComponent();
            AllocConsole();

            //qb.renderall(40);

            img1.Image = qb.renderpre(128,24,70);


        }

        int imgres = 512;
        int iter = 192;

        private void img1_MouseClick(object sender, MouseEventArgs e)
        {
            double mx = (double)e.X / img1.Width,my = (double)e.Y / img1.Height;
            
            img2.Image = qb.renderpt_jk( mx * 2 - 1 , my * 2 - 1 , iter , imgres, render_pb);

        }

        private void img2_MouseClick(object sender, MouseEventArgs e)
        {
            double mx = (double)e.X / img1.Width, my = (double)e.Y / img1.Height;

            img1.Image = qb.renderpt_ri(mx * 2 - 1, my * 2 - 1, iter, imgres, render_pb);

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        
    }
}
