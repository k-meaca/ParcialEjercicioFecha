using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialEjercicioFecha.Entidades
{
    public class Fecha
    {
        //ATRIBUTOS
        private int Dia, Mes, Anio;
        private DateTime miFecha;
        private Mes meses;

        //CONSTRUCTORES

        /// <summary>
        /// Construye una fecha
        /// </summary>
        /// <param name="dia">Dia del año, ej: 11</param>
        /// <param name="mes">Mes del año, ej: 7</param>
        /// <param name="anio">Debe contener los 4 digitos del año, ej: 1994</param>
        public Fecha(int dia, int mes, int anio)
        {
            if (!ValidarFecha(dia, mes, anio))
                throw new ArgumentException("La fecha debe ser por ej: 19/03/1998. Controlar que el año sea biciesto.");

            this.Dia = dia;
            this.Mes = mes;
            this.Anio = anio;
        }

        public Fecha() : this(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year) { }

        //METODOS


        //PRIVADOS

        private bool ValidarFecha(int dia, int mes, int anio)
        {
            bool valido = true;

            if ((Mes)mes != Entidades.Mes.Febrero && (dia < 1 || dia > 31))
                valido = false;
            else if ((Mes)mes == Entidades.Mes.Febrero)
            {
                if (EsBiciesto(anio))
                {
                    if (dia < 1 || dia > 29)
                        valido = false;
                }
                else if (dia < 1 || dia > 28)
                    valido = false;
            }
            else if (anio.ToString().Length < 4)
                valido = false;
            else if (mes < 1 || mes > 12)
                valido = false;

            return valido;
        }

        private bool EsBiciesto(int anio)
        {
            if (anio % 4 == 0 && (anio % 100 != 0 || anio % 400 == 0))
                return true;
            else
                return false;
        }

        private static bool FechaStringValida(string fecha, out int dia, out int mes, out int anio)
        {
            string[] datos = fecha.Split('/');
            bool fechaValida = true;

            if (datos.Length < 3)
                fechaValida = false;
            else if (datos[2].Length < 4)
                fechaValida = false;

            dia = Convert.ToInt32(datos[0]);
            mes = Convert.ToInt32(datos[1]);
            anio = Convert.ToInt32(datos[2]);

            return fechaValida;
        }

        //PUBLICOS
        public string ObtenerFecha()
        {
            return $"{Dia}/{Mes}/{Anio}";
        }

        public string ObtenerFechaConMesEscrito()
        {
            return $"{Dia} de {(Mes)Mes} del {Anio}";
        }

        public static bool operator ==(Fecha fecha, Fecha otraFecha)
        {
            return fecha.ObtenerFecha() == otraFecha.ObtenerFecha();
        }

        public static bool operator !=(Fecha fecha, Fecha otraFecha)
        {
            return !(fecha == otraFecha);
        }

        public static implicit operator Fecha(string fecha)
        {

            if (!FechaStringValida(fecha, out int dia, out int mes, out int anio))
            {
                throw new InvalidCastException("No es posible convertir ese formato en fecha. Debe ser por ej. 19/04/1996");
            }

            return new Fecha(dia, mes, anio);

        }
    }
}
