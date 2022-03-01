using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quad
{
    class quad
    {
        public double r, i, j, k;

        public quad()
        {
            r = 0;
            i = 0;
            j = 0;
            k = 0;
        }

        public quad(double r, double i, double j, double k)
        {
            this.r = r;
            this.i = i;
            this.j = j;
            this.k = k;
        }

        public double mod()
        {
            return Math.Sqrt(r * r + i * i + j * j + k * k);
        }

        public static quad operator +(quad a, quad b) => new quad(a.r + b.r, a.i + b.i, a.j + b.j, a.k + b.k);

        public static quad operator *(quad a, quad b) => new quad(
            a.r * b.r - a.i * b.i - a.j * b.j - a.k * b.k,
            a.r * b.i + a.r * b.r + a.j * b.k - a.r * b.j,
            a.r * b.j + a.j * b.k + a.j * b.r - a.k * b.i,
            a.r * b.k + a.i * b.j + a.j * b.i - a.k * b.r);

    }
}
