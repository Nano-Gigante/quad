using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //renders everything not recommended
            for (int r = 0; r < size; r++)
            {
                for (int i = 0; i < size; i++)
                {
                    int totiter = 0;
                    for (int j = 0; j < size; j++)
                        for (int k = 0; k < size; k++)
                        {
                            int cnt = (int)(mandelbrot4D((double)r / size * 2 - 1, (double)i / size * 2 - 1, (double)j / size * 2 - 1, (double)k / size * 2 - 1, iter) * iter);

                            totiter += cnt;
                            matrix[r, i, j, k] = cnt;
                        }

                    pre[r, i] = totiter;
                }
                Console.WriteLine(r + " / " + size);
            }
        }

        public Bitmap renderpre(int tres, int nres, int iter)
        {
            /*
             * tres = resolution of the r/i image
             * nres = resolution of the j/k calculations
             * max = maximum number of iterations
             */
            
            double[,] pre = new double[tres, tres];
            double max = 0;

            
            for (int r = 0; r < tres; r++)
            {
                for (int i = 0; i < tres; i++)
                {   
                    //for every plane it calculates the total number of iterations for the set of points (-1...1...2/nres,-1...1...2/nres)
                    //note: iterations are not ints but doubles that range from 0 to 1 where 0 means 0 and 1 means $iter
                    pre[r, i] = 0;
                    for (int j = 0; j < nres; j++)
                        for (int k = 0; k < nres; k++)
                        {

                            double val = mandelbrot4D((double)r / tres * 2 - 1, (double)i / tres * 2 - 1, (double)j / nres * 2 - 1, (double)k / nres * 2 - 1, iter);
                            pre[r, i] += val;
                        }
                    //keeps track of the maximum iterations reached (for coloring purposes)
                    max = Math.Max(max, pre[r, i]);
                }
                Console.WriteLine(r + " / " + tres);
            }

            //renders the bitmap
            Bitmap bmp = new Bitmap(tres, tres);

            for (int r = 0; r < tres; r++)
                for (int i = 0; i < tres; i++) {
                    try
                    {
                        Color c = Mandelbrot.rainbow(pre[r, i] / max);

                        bmp.SetPixel(r, i, c);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(pre[r, i] + "  " + max);
                    }
                        
                }

            return bmp;
        }

        
        public Bitmap renderpt_jk(double r,double i,int iter,int res,ProgressBar pb)
        {
            Bitmap bmp = new Bitmap(res, res);

            for(int j = 0; j < res; j++)
            {
                for(int k = 0;k < res; k++)
                {
                    double val =  mandelbrot4D(r, i, (double)j / res * 2 - 1, (double)k / res * 2 - 1,iter);
                    bmp.SetPixel(j, k, Mandelbrot.rainbow(val));
                }
                pb.Value = (int)((double)j / res * 100);
            }
            pb.Value = 100;

            return bmp;
        }

        public Bitmap renderpt_ri(double j, double k, int iter, int res, ProgressBar pb)
        {
            Bitmap bmp = new Bitmap(res, res);

            for (int r = 0; r < res; r++)
            {
                for (int i = 0; i < res; i++)
                {
                    double val = mandelbrot4D((double)r / res * 2 - 1, (double)i / res * 2 - 1,j,k,iter);
                    bmp.SetPixel(r, i, Mandelbrot.rainbow(val));
                }
                pb.Value = (int)((double)r / res * 100);
            }
            pb.Value = 100;

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
                    //Console.Write(matrix[ir, ii, j, k] + " ");
                }
                //Console.WriteLine("");
            }

            for (int j = 0; j < size; j++)
                for (int k = 0; k < size; k++)
                    bmp.SetPixel(j, k, Mandelbrot.rainbow((double)matrix[ir, ii, j,k] / max));

            return bmp;
        }

        
        public double mandelbrot4D(double r, double i,double j,double k,int iter)
        {
            quad z = new quad();
            quad c = new quad(r,i,j,k);
            int cnt = 0;

            while (z.mod() < 2 && cnt < iter)
            {
                z = z * z + c;
                cnt++;
            }

            return (double)cnt / iter;
        }

        public Bitmap renderpoint(double r, double i)
        {
            return null;
        }



    }
}
