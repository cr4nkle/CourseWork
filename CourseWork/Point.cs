using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public abstract class Point // добавить наследование от одного класса
    {
        public float X; 
        public float Y;
        public Color Color;        

        public abstract void PaintParticle(Particle particle);
        public abstract void Render(Graphics g);
    }

    public class PaintPoint:Point
    {
        public float X1;
        public float Y1;

        public override void PaintParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < 100 / 2 + X1 / 2)
            {
                if (particle is ParticleColorful)
                {
                    var p = (particle as ParticleColorful);
                    p.FromColor = Color;
                    p.ToColor = Color;
                }

            }

        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color),
                X - 50 - X1 / 2,
                Y - 50 - Y1 / 2,
                X1 + 100,
                Y1 + 100
            );
        }
    }


    public class CountPoint:Point
    {
        private int count;
        public override void PaintParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < 100 / 2)
            {
                if (particle is ParticleColorful)
                {
                    count++;                    
                }

            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color),
                X - 50,
                Y - 50,
                100,
                100
            );

            g.DrawString(
            $"{count}", 
            new Font("Verdana", 10), 
            new SolidBrush(Color.Black),
            X, 
            Y
        );
        }
    }

    public class EnterPoint : Point
    {
        public ExitPoint exitPoint;
        public int Angle = 0;
        public override void PaintParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < 100 / 2)
            {
                if (particle is ParticleColorful)
                {
                    var p = (particle as ParticleColorful);

                    var m = new Matrix();
                    m.Rotate(Angle);

                    var points = new[] { new PointF(gX, gY) ,  new PointF(p.SpeedX, p.SpeedY)};
                    m.TransformPoints(points);

                    p.X = exitPoint.X - points[0].X;
                    p.Y = exitPoint.Y - points[0].Y;
                    p.SpeedX = points[1].X;
                    p.SpeedY = points[1].Y;
                }

            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
               new Pen(Color),
               X - 50,
               Y - 50,
               100,
               100
           );
        }
    }

    public class ExitPoint : Point
    {
        

        public override void PaintParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < 100 / 2)
            {
                if (particle is ParticleColorful)
                {
                    var p = (particle as ParticleColorful);
                    

                }

            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color),
                X - 50,
                Y - 50,
                100,
                100
            );
        }
    }
}
