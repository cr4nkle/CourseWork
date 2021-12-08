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
        Emitter emitter = new Emitter();

        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            });

            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });
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
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
