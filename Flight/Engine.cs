using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight
{
	class Engine
	{
        const double dt = 0.1;
        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;

        public double a;
        public double v0;
        public double y0;
        public double S;
        public double m;
        double k;

        public double t;
        public double x;
        public double y;
        public double vx;
        public double vy;

      

       
		
		public void start(Form1 form)
		{
           form.start();
            k = 0.5 * C * S * rho / m;

            vx = v0 * Math.Cos(a * Math.PI / 180);
            vy = v0 * Math.Sin(a * Math.PI / 180);

            t = 0;
            x = 0;
            y = y0;
        }

        public void tick()
		{
            t += dt;
            vx = vx - k * vx * Math.Sqrt(vx * vx + vy * vy) * dt;
            vy = vy - (g + k * vy * Math.Sqrt(vx * vx + vy * vy)) * dt;

            x = x + vx * dt;
            y = y + vy * dt;
        }
    }
}
