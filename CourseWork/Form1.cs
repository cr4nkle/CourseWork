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
        PaintPoint redPoint, blackPoint, whitePoint;
        EnterPoint ep;
        ExitPoint exp;
        public Form1()
        {
            InitializeComponent();
            picDisplay.MouseWheel += pickDisplay_MouseWheel;

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 30,
                X = 0,
                Y = picDisplay.Height / 2,
                
            };

            emitters.Add(this.emitter);

            redPoint = new PaintPoint
            {
                Color = Color.Red,
                X = picDisplay.Width / 2,
                Y = (float)(picDisplay.Height * 0.25),
                X1 = 100,
                Y1 = 100
            };

            whitePoint = new PaintPoint
            {
                Color = Color.White,
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2,
                X1 = 100,
                Y1 = 100
            };

            blackPoint = new PaintPoint
            {
                Color = Color.Black,
                X = (float)(picDisplay.Width * 0.5),
                Y = picDisplay.Height / 2,
                X1 = 100,
                Y1 = 100
            };
            
            emitter.impactPoints.Add(redPoint);
            emitter.impactPoints.Add(whitePoint);// конец перекрашивания
            emitter.impactPoints.Add(blackPoint);
            exp = new ExitPoint//телепорт
            {
                Color = Color.Blue,
                X = (float)(picDisplay.Width * 0.5),
                Y = picDisplay.Height / 2,
                X1 = 100,
                Y1 = 100
            };
            ep = new EnterPoint
            {
                exitPoint = exp,
                Color = Color.Purple,
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2,
                X1 = 100,
                Y1 = 100
            };
            
            emitter.impactPoints.Add(ep);
            emitter.impactPoints.Add(exp);// конец телепорта
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
            exp.X = e.X;
            exp.Y = e.Y;
            //point.X = e.X;
            //point.Y = e.Y;
        }

        private void pickDisplay_MouseWheel(object sender, MouseEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ep.Angle = trackBar1.Value;
            //redPoint.X1 = trackBar1.Value;
            //redPoint.Y1 = trackBar1.Value;
            //whitePoint.X1 = trackBar1.Value;
            //whitePoint.Y1 = trackBar1.Value;
            //blackPoint.X1 = trackBar1.Value;
            //blackPoint.Y1 = trackBar1.Value;

        }
    }
}
