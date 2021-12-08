﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CourseWork
{
    public class Particle
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

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 50);
            int alpha = (int)(k * 255); 
            var color = Color.FromArgb(alpha, Color.OrangeRed);
            var brush = new SolidBrush(color);
            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor;
        public Color ToColor;

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}

