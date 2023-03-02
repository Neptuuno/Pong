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
            KeyPreview = true;
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

            if (button1.Bounds.IntersectsWith(button2.Bounds))
            {
                X *= -1;
                Y *= -1;
            }

            if (button1.Bounds.IntersectsWith(button3.Bounds))
            {
                X *= -1;
                Y *= -1;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int y1 = button2.Location.Y;
            int y2 = button3.Location.Y;

            if (e.KeyCode == Keys.W)
            {
                if (button2.Location.Y > 0)
                    y1 -= 8;
            }

            if (e.KeyCode == Keys.S)
            {
                if (button2.Location.Y + button2.Height < ClientSize.Height)
                    y1 += 8;
            }

            if (e.KeyCode == Keys.I)
            {
                if (button3.Location.Y > 0)
                    y2 -= 8;
            }

            if (e.KeyCode == Keys.K)
            {
                if (button3.Location.Y + button2.Height < ClientSize.Height)
                    y2 += 8;
            }

            button2.Location = new Point(button2.Location.X, y1);
            button3.Location = new Point(button3.Location.X, y2);
        }
    }
}