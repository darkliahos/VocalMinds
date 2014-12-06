using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

//imports drawing library (for the 2D drawing stuff)

namespace VM_Main
{
    public partial class FrmScribblePad : Form
    {
        private bool _mouseButtonDown; //boolean to check if the mouse button is down
        private Point _paintpoint = Point.Empty;//Records where the mouse was last clicked
        private readonly Graphics _graphic;
        private Pen _pen;

        public FrmScribblePad()
        {
            InitializeComponent();
            _graphic = CreateGraphics();
            _graphic.SmoothingMode = SmoothingMode.AntiAlias;
            _pen = new Pen(Color.Black);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseButtonDown = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseButtonDown = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_paintpoint.Equals(Point.Empty)) _paintpoint = new Point(e.X, e.Y);
            if (_mouseButtonDown)
            {
                Point pMousePos = new Point(e.X, e.Y);
                _graphic.DrawLine(_pen, pMousePos, _paintpoint);
            }
            _paintpoint = new Point(e.X, e.Y);
        }

        private void BtnredClick(object sender, EventArgs e)
        {
            _pen = new Pen(Color.Red);
        }

        private void BtnblueClick(object sender, EventArgs e)
        {
            _pen = new Pen(Color.Blue);
        }

        private void Button3Click(object sender, EventArgs e)
        {
            _pen = new Pen(Color.Black);
        }

        private void Button2Click(object sender, EventArgs e)
        {
            _pen = new Pen(Color.White);
        }

        private void BtngreenClick(object sender, EventArgs e)
        {
            _pen = new Pen(Color.Green);
        }

        private void BtnyellowClick(object sender, EventArgs e)
        {
            _pen = new Pen(Color.Yellow);
        }
    }
}
