using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
    public abstract class ImpactPoint
    {
        public float X; 
        public float Y;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.Purple),
                X - 5,
                Y - 5,
                10,
                10
            );
        }
    }   
}
