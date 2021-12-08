using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CourseWork
{
    class Particle
    {
        public int Radius; 
        public float X; 
        public float Y; 
        public float Direction; 
        public float Speed;
        public float Life;

        public static Random rand = new Random();

        public Particle()
        {
            Radius = 2 + rand.Next(10);
            Direction = rand.Next(360);
            Speed = 1 + rand.Next(10);
            Life = 20 + rand.Next(100);

        }

        public void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 50);
            int alpha = (int)(k * 255); 
            var color = Color.FromArgb(alpha, Color.OrangeRed);
            var brush = new SolidBrush(color);
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
        }
    }
}
