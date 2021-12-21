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
        Random rnd;

        Dictionary<int, Color> colorList = new Dictionary<int, Color> { 
            [0] = Color.Blue,
            [1] = Color.Red,
            [2] = Color.White,
            [3] = Color.Purple,
            [4] = Color.Black,
            [5] = Color.Pink,
            [6] = Color.Yellow,
            [7] = Color.Green,
            [8] = Color.Orange,
            [9] = Color.DarkGray,
        };
        public Form1()
        {
            InitializeComponent();
            picDisplay.MouseWheel += pickDisplay_MouseWheel;

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            emitter = new Emitter 
            {
                Direction = 0,
                Spreading = 0,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 30,
                X = 0,
                Y = picDisplay.Height / 2,
                
            };

            emitters.Add(emitter);

            redPoint = new PaintPoint
            {
                Color = Color.Red,
                X = (float)(picDisplay.Width * 0.6),
                Y = (float)(picDisplay.Height * 0.75),
                X1 = 100,
                Y1 = 100
            };

            whitePoint = new PaintPoint
            {
                Color = Color.White,
                X = (float)(picDisplay.Width * 0.6),
                Y = (float)(picDisplay.Height * 0.5),
                X1 = 100,
                Y1 = 100
            };

            blackPoint = new PaintPoint
            {
                Color = Color.Black,
                X = (float)(picDisplay.Width * 0.6),
                Y = (float)(picDisplay.Height * 0.25),
                X1 = 100,
                Y1 = 100
            };
            
            emitter.impactPoints.Add(redPoint);
            emitter.impactPoints.Add(whitePoint);
            emitter.impactPoints.Add(blackPoint);

            exp = new ExitPoint
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
            emitter.impactPoints.Add(exp);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rnd = new Random();
            redPoint.Color = colorList[rnd.Next(0,10)];
            whitePoint.Color = colorList[rnd.Next(0, 10)];
            blackPoint.Color = colorList[rnd.Next(0, 10)];
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            lblSpr.Text = $"Изменение угла разброса {trackBar2.Value}°";
            emitter.Spreading = trackBar2.Value;
        }

        private void pickDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            rnd = new Random();
            redPoint.Color = colorList[rnd.Next(0, 10)];
            whitePoint.Color = colorList[rnd.Next(0, 10)];
            blackPoint.Color = colorList[rnd.Next(0, 10)];
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            lblAngle.Text = $"Изменение угла на {trackBar1.Value}°";
            ep.Angle = trackBar1.Value;          

        }
    }
}
