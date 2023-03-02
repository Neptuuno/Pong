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
        private int _x = 2;
        private int _y = 2;
        private int gPoints = 0;
        private int rPoints = 0;
        private short rounds = 1;
        private Point ballLocation = new Point(322, 225);

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            DoubleBuffered = true;
            KeyPreview = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (rounds % 10 == 0)
            {
                _x++;
                _y++;
            }
            redLabel.Text = rPoints.ToString();
            greenLabel.Text = gPoints.ToString();
            if (button1.Location.Y + button1.Height >= ClientSize.Height)
            {
                _y *= -1;
            }

            if (button1.Location.X + button1.Width >= ClientSize.Width)
            {
                gPoints++;
                button1.Location = ballLocation;
                rounds++;
            }

            if (button1.Location.X <= 0)
            {
                rPoints++;
                button1.Location = ballLocation;
                rounds++;
            }

            if (button1.Location.Y <= 0)
            {
                _y *= -1;
            }

            button1.Location = new Point(button1.Location.X + _x, button1.Location.Y + _y);

            if (button1.Bounds.IntersectsWith(button2.Bounds))
            {
                _x *= -1;
                _y *= -1;
            }

            if (button1.Bounds.IntersectsWith(button3.Bounds))
            {
                _x *= -1;
                _y *= -1;
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