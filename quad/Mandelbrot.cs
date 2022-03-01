using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace quad
{
    class Mandelbrot
    {
		public double w, h, res;
		public double offw, offh;
		public int iw, ih;
		public Bitmap bmp ;

		protected Mandelbrot()
		{
		}

		public Mandelbrot(double woffset, double hoffset, double w, double h, double res)
		{
			this.res = res;
			this.w = w;
			this.h = h;
			this.offw = woffset;
			this.offh = hoffset;
			iw = (int)res; //(int)(res * w);
			ih = (int)res; //(int)(res * h);

			bmp = new Bitmap(ih, iw);
		}

		public void render(int iter)
		{

			double diw = iw, dih = ih;

			for (int x = 0; x < iw; x++)
			{
				for (int y = 0; y < ih; y++)
				{
					double n = mandelbrot(w * ((double)x / diw - 0.5) + offw, h * ((double)y / dih - 0.5) + offh, iter);

					n = Math.Sqrt(n);
					Color color;
					if (n == 1)
						color = Color.Black;
					else
						color = rainbow(n);
					bmp.SetPixel(y, x, color);
				}
			}

		}


		public double mandelbrot(double x, double y, int iter)
		{
			Complex z = new Complex();
			Complex c = new Complex(x, y);

			for (int i = 0; i < iter; i++)
			{
				z = z * z + c;
				if (z.Magnitude > 2)
					return (double)i / (double)iter;
			}
			return 1.0;
		}

		void save(String filename)
		{

		}

		public static Color rainbow(double v)
		{
			double r = 0.5 * (Math.Sin(2 * Math.PI * v) + 1) * 255.0;
			double g = 0.5 * (Math.Sin(2 * Math.PI * v + 2.0 / 3.0 * Math.PI) + 1) * 255.0;
			double b = 0.5 * (Math.Sin(2 * Math.PI * v + 4.0 / 3.0 * Math.PI) + 1) * 255.0;
			//System.out.println(v + " " + r + " " + g + " " + b);
			return Color.FromArgb((int)r,(int)g,(int)b);
		}

	}
}
