using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    class Utilities
    {
        /// <summary>
        /// Generar un numero pseudo-aleatorio.
        /// </summary>
        /// <returns>Numero pseudo-aleatorio.</returns>
        public static int RandInt()
        {
            Random randomInstance = new Random();
            int randomValue = randomInstance.Next(0, 255);

            return randomValue;
        }

        /// <summary>
        /// Discierne si es que existe un string dado en un arreglo de strings.
        /// </summary>
        /// <param name="word">String objetivo</param>
        /// <param name="array">Array a analizar</param>
        /// <returns>Valor booleano resultado del analisis. true si es que el arreglo contiene a la palabra; de otro modo false.</returns>
        public static Boolean IsWordInArray(string word, string[] array)
        {
            foreach (string element in array)
            {
                if (String.Compare(element, word, true) == 0)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Analiza si ciertas palabras se encuentran en un string cuyas palabas se encuentran separadas por espacios.
        /// </summary>
        /// <param name="keywords">Arreglo con palabras objetivo.</param>
        /// <param name="input">String a analizar.</param>
        /// <returns>Valor booleano resultado del analisis. true si todas las palabras se hayan en el string; de otro modo false.</returns>
        public static Boolean AreKeywordsInInput(String[] keywords, String input)
        {
            foreach (String singleKeyword in keywords)
            {
                if (!IsWordInArray(singleKeyword, input.Split(' ')))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Obtener el promedio de un arreglo de enteros.
        /// </summary>
        /// <param name="array">Arreglo a analizar.</param>
        /// <returns>Valor numerico que indica el promedio del contenido del arreglo.</returns>
        public static double GetAverage(int[] array)
        {
            double average;
            int sum = 0;

            foreach (int number in array)
                sum = sum + number;

            average = (double) sum / (double) array.Length;
            return average;
        }

        /// <summary>
        /// Obtener el valor minimo de un arreglo de enteros.
        /// </summary>
        /// <param name="array">Arreglo a analizar.</param>
        /// <returns>Numero entero que indica el valor minimo del arreglo.</returns>
        public static int Min(int[] array)
        {
            int min = array[0];

            if (array.Length == 1)
                return min;
            
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
            }

            return min;
        }

        /// <summary>
        /// Obtener el valor maximo de un arreglo de enteros.
        /// </summary>
        /// <param name="array">Arreglo a analizar</param>
        /// <returns>Numero entero que indica el valor maximo del arreglo.</returns>
        public static int Max(int[] array)
        {
            int max = array[0];

            if (array.Length == 1)
                return max;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                    max = array[i];
            }

            return max;
        }
    }
}
