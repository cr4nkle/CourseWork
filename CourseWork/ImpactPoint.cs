using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public class ImpactPoint
    {
        public float X; 
        public float Y;
        public float X1;
        public float Y1;

        public void ImpactParticle(Particle particle)
        {

            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < 100 / 2) // если частица оказалось внутри окружности
            {
                if (particle is ParticleColorful) {
                    var p = (particle as ParticleColorful);
                    (particle as ParticleColorful).FromColor = Color.Blue;
                    p.ToColor = Color.Blue;
                }
               
            }
        }

        public virtual void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color.Blue),
                X-50,
                Y-50,
                X1+100,
                Y1+100
            );
        }
    }   
}
