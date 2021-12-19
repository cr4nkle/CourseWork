using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        Emitter emitter;
        ImpactPoint point;
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            point = new ImpactPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitter.impactPoints.Add(point);            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }        

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.LightBlue);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

        private void pickDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            point.X = e.X;
            point.Y = e.Y;
        }

        private void pickDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            point.X1 = e.X;
            point.Y1 = e.Y;
        }
    }
}
