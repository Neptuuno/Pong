using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int X = 2;
        int Y = 2;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            DoubleBuffered = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Location.Y + button1.Height >= ClientSize.Height)
            {
                Y *= -1;
            }
            if (button1.Location.X + button1.Width >= ClientSize.Width)
            {
                X *= -1;
            }
            if (button1.Location.X <= 0)
            {
                X *= -1;
            }
            if (button1.Location.Y <= 0)
            {
                Y *= -1;
            }
            button1.Location = new Point(button1.Location.X + X, button1.Location.Y + Y);
        }
    }
}