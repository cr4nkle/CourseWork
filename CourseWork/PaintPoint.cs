using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class PaintPoint
    {
        public float X; 
        public float Y;
        public Color PaintColor;
        public float X1;
        public float Y1;

        public void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); 
            if(r + particle.Radius < 100/2 + X1/2)
            {
                if (particle is ParticleColorful) {
                    var p = (particle as ParticleColorful);
                    p.FromColor = PaintColor;
                    p.ToColor = PaintColor;
                }

            }
            
        }

        public void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(PaintColor),
                X-50-X1/2,
                Y-50-Y1/2,
                X1+100,
                Y1+100
            );
        }
    }     
    
}
