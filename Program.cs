using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace cylindre
{
    //definition delegate

    public delegate double airdelegate(double pi, int rayon);
    public delegate double volumedelegate(int h, int rayon);
    public delegate double surfacedelegate(int rayon, int h);
    public delegate double surfacelateraledelegate(int rayon, int h);
    internal class Cylindre
    {

        public const double pi = 3.14;

        public double air(double pi, int rayon)
        {
            return (pi * rayon * rayon);
        }



        public double volume(int h, int rayon)
        {
            return h * air(pi, rayon);
        }

        public double surface(int rayon, int h)
        {
            return (2 * air(pi, rayon) + 2 * pi * rayon * h);

        }
        //nouvelle fonctionnalite
        public double CalculerSurfaceLaterale(int rayon,int h)
        {
            double surfaceLaterale = 2 * Math.PI * rayon * h;
            return surfaceLaterale;
        }


        static void Main(string[] args)
        {
            //instanciation de la classe
            Cylindre c1 = new Cylindre();

            double var = c1.air(pi, 4);
            Console.WriteLine(var);

            double var1 = c1.volume(4, 6);
            Console.WriteLine(var1);

            /*double var2 = c1.volume(6, 4);
            Console.WriteLine(var2);*/

            double var2 = c1.surface(6, 4);
            Console.WriteLine(var2);


            double var3 = c1.CalculerSurfaceLaterale(3, 5);
            Console.WriteLine(var3);


            //instanciation delegate

            airdelegate aird = new airdelegate(c1.air);

            volumedelegate volumed = new volumedelegate(c1.volume);

            surfacedelegate surfaced = new surfacedelegate(c1.surface);

            surfacelateraledelegate surfaceL = new  surfacelateraledelegate(c1.CalculerSurfaceLaterale);



            //appelation delegate

            aird.Invoke(pi, 4);

            volumed.Invoke(6, 4);

            surfaced.Invoke(4, 6);

            surfaceL.Invoke(6, 4);






        }
    }
}
