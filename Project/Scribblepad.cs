using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;//imports drawing library
using System.Drawing.Drawing2D;//imports drawing library (for the 2D drawing stuff)
using System.Windows.Forms;

namespace Project
{
    public partial class Scribblepad : Form
    {
        private bool mouseButtonDown = false;//boolean to check if the mouse button is down
        private Point paintpoint = Point.Empty;//Records where the mouse was last clicked
        private Graphics g;
        private Pen p;

        public Scribblepad()
        {
            InitializeComponent();
        }

        private void Scribblepad_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            p = new Pen(Color.Black);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseButtonDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseButtonDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (paintpoint.Equals(Point.Empty)) paintpoint = new Point(e.X, e.Y);
            if (mouseButtonDown)
            {
                Point pMousePos = new Point(e.X, e.Y);
                g.DrawLine(p, pMousePos, paintpoint);
            }
            paintpoint = new Point(e.X, e.Y);
        }

        private void btnred_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Red);
        }

        private void btnblue_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Blue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Black);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.White);
        }

        private void btngreen_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Green);
        }

        private void btnyellow_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Yellow);
        }
    }
}
