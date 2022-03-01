using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace quad
{
    class quadbrot
    {

        public int[,,,] matrix;
        public int[,] pre;
        
        double range = 1;
        int size = 128;


        public quadbrot()
        {
            matrix = new int[size, size, size, size];
            pre = new int[size, size];
        }

        public void renderall(int iter){

            for (int r = 0; r < size; r++)
            {
                for (int i = 0; i < size; i++)
                {
                    int totiter = 0;
                    for (int j = 0; j < size; j++)
                        for (int k = 0; k < size; k++)
                        {
                            quad z = new quad();
                            quad c = new quad((double)r / size * 2 - 1, (double)i / size * 2 - 1, (double)j / size * 2 - 1, (double)k / size * 2 - 1);
                            int cnt = 0;

                            while (z.mod() < 2 && cnt < iter)
                            {
                                z = z * z + c;
                                cnt++;
                            }

                            totiter += cnt;
                            matrix[r, i, j, k] = cnt;
                        }

                    pre[r, i] = totiter;
                }
                Console.WriteLine(r + " / " + size);
            }
        }

        public Bitmap renderpre()
        {
            int max = 0;
            Bitmap bmp = new Bitmap(size, size);


            for (int r = 0; r < size; r++)
            {
                for (int i = 0; i < size; i++)
                {
                    max = Math.Max(max, pre[r, i]);
                    Console.Write(pre[r, i] + " ");
                }
                Console.WriteLine("");
            }

            for (int r = 0; r < size; r++)
                for (int i = 0; i < size; i++)
                    bmp.SetPixel(r, i, Mandelbrot.rainbow((double)pre[r, i] / max));

            return bmp;
        }

        public Bitmap renderpt(double r,double i)
        {
            int max = 0;
            Bitmap bmp = new Bitmap(size, size);

            int ir = (int)((r + 1) / 2 * size ), ii = (int)( (i + 1 ) / 2 * size );
            for (int j = 0; j < size; j++)
            {
                for (int k = 0; k < size; k++)
                {
                    max = Math.Max(max, matrix[ir, ii , j , k]);
                    Console.Write(matrix[ir, ii, j, k] + " ");
                }
                Console.WriteLine("");
            }

            for (int j = 0; j < size; j++)
                for (int k = 0; k < size; k++)
                    bmp.SetPixel(j, k, Mandelbrot.rainbow((double)matrix[ir, ii, j,k] / max));

            return bmp;
        }

        public Bitmap renderpoint(double r, double i)
        {
            return null;
        }

    }
}
