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
        List<Emitter> emitters = new List<Emitter>();
        
        Emitter emitter;
        ImpactPoint point;
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            /*this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);*/

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            point = new ImpactPoint
            {
                PaintColor = Color.Blue,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                X1 = 20,
                Y1 = 20,
            };
            emitter.impactPoints.Add(point);

            emitter.impactPoints.Add(new ImpactPoint
            {
                PaintColor = Color.Red,
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            emitter.impactPoints.Add(new ImpactPoint
            {
                PaintColor = Color.White,
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
            point.X = e.X;
            point.Y = e.Y;
        }

        private void pickDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            point.X1 = e.X;
            point.Y1 = e.Y;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            point.X1 = trackBar1.Value;
            point.Y1 = trackBar1.Value;

        }
    }
}
