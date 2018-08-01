using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Chatbot
{
    class DateTimeHandler
    {
        /// <summary>
        /// Obtener la hora del sistema.
        /// </summary>
        /// <returns>Arreglo de enteros con la hora. Formato: [Hora, Minuto, Segundo]</returns>
        public static int[] GetTime()
        {
            System.DateTime moment = new System.DateTime();
            int hour = moment.Hour;
            int minute = moment.Minute;
            int second = moment.Second;
            int[] finalTime = { hour, minute, second };

            return finalTime;
        }

        /// <summary>
        /// Obtener la fecha del sistema.
        /// </summary>
        /// <returns>Arreglo de enteros con la fecha. Formato: [Dia, Mes, Ciclo de 365 dias]</returns>
        public static int[] GetDate()
        {
            System.DateTime moment = new System.DateTime();

            int year = moment.Year;
            int month = moment.Month;
            int day = moment.Day;

            int[] finalDate = { day, month, year };

            return finalDate;
        }
        /// <summary>
        /// Obtener la hora o la fecha en formato string.
        /// </summary>
        /// <param name="selector"> Discierne si se retorna la hora o la fecha. "time" para la hora; "date" para la fecha.</param>
        /// <returns>String con el contenido especificado en la entrada.</returns>
        public static string GetString(string selector)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("fr-FR");
            string resultantDateTime = localDate.ToString(culture);

            // Obtener fecha.
            if (selector == "date")
                return (resultantDateTime.Split(' ')[0]);

            // Obtener hora.
            else if (selector == "time")
                return (resultantDateTime.Split(' ')[1]);

            // Notificar error.
            else
                return "Error";

        }

        /// <summary>
        /// Obtener un string con la hora, pero usando caracteres permitidos para nombres de archivos.
        /// </summary>
        /// <returns>string compatible con los nombres de archivo.</returns>
        public static string GetStringTimeSpecial()
        {
            int[] time = GetTime();
            string finalTime = time[0].ToString() + "-" + time[1].ToString() + "-" + time[2].ToString();

            return finalTime;
        }

        /// <summary>
        /// Obtener un string con la fecha, pero usando caracteres permitidos para nombres de archivos.
        /// </summary>
        /// <returns>string compatible con los nombres de archivos.</returns>
        public static string GetStringDateSpecial()
        {
            int[] date = GetDate();
            string finalDate = date[0].ToString() + "-" + date[1].ToString() + "-" + date[2].ToString();

            return finalDate;
        }

        /// <summary>
        /// Formar un nombre de archivo provisional.
        /// </summary>
        /// <returns>string compatible con los nombres de archivos.</returns>
        public static string CreateFileName()
        {
            string filename = GetStringDateSpecial() + "_" + GetStringTimeSpecial();

            return filename;
        }
    }
}
