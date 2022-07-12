using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParcialEjercicioFecha.Entidades;

namespace ParcialEjercicioFecha.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fecha miFecha = new Fecha(11, 11, 1994);

                Console.WriteLine(miFecha.ObtenerFecha());

                Console.WriteLine(miFecha.ObtenerFechaConMesEscrito());

                Fecha otraFecha = "18/4/1996";

                if (miFecha != otraFecha)
                {
                    Console.WriteLine("Fechas distintas");
                    Console.WriteLine($"{nameof(miFecha)} : {miFecha.ObtenerFecha()}");

                    Console.WriteLine($"{nameof(otraFecha)} : {otraFecha.ObtenerFecha()}");
                }
                else
                {
                    Console.WriteLine("Son iguales");
                }

                Fecha fechaBiciesta = new Fecha(29,2,2024);

                Console.WriteLine(fechaBiciesta.ObtenerFecha());

                //Fecha fechaIncorrecta;

                //fechaIncorrecta = new Fecha(23, -1, 1999);

                //fechaIncorrecta = new Fecha(33, 2, 2000);

                //fechaIncorrecta = new Fecha(20, 7, 99);

                //fechaIncorrecta = "1999-21-02";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
