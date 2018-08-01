using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class Log
    {
        List<string> log;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Log()
        {
            log = new List<string>();
        }

        /// <summary>
        /// Agregar un elemento al Log.
        /// </summary>
        /// <param name="message">Elemento a agregar.</param>
        public void AppendMessage(string message)
        {
            log.Add(message);
        }

        /// <summary>
        /// Retornar un elemento dado un indice de entrada.
        /// </summary>
        /// <param name="index">Indice</param>
        /// <returns>Valor asociado al indice de entrada.</returns>
        public string Get(int index)
        {
            if (index < 0)
                return "";

            if (index >= log.Count)
                return "";

            return log[index];
        }

        /// <summary>
        /// Borra el contenido del Log.
        /// </summary>
        public void Clean()
        {
            log.Clear();
        }
        
        /// <summary>
        /// Modificar el contenido de un elemento del Log.
        /// </summary>
        /// <param name="index">Indice que apunta al elemento a reemplazar.</param>
        /// <param name="message">Elemento que sustituira al anterior.</param>
        public void Redefine(int index, string message)
        {
            log[index] = message;
        }

        /// <summary>
        /// Obtener el numero de elementos del Log.
        /// </summary>
        /// <returns>Valor numerico que representa la cantidad de elementos del Log.</returns>
        public int Length()
        {
            return log.Count;
        }

        /// <summary>
        /// Crea un nuevo archivo que guarda los contenidos del Log actual.
        /// </summary>
        public void WriteLog()
        {
            if (log.Count == 0)
                return;

            string[] content = new string[log.Count];

            for (int i = 0; i < log.Count; i++)
                content[i] = log[i];

            InputOutput.SaveLogInFile(content);
            
        }

        /// <summary>
        /// Carga los contenidos de un archivo de texto en el log actual, borrando toda la informacion previa.
        /// </summary>
        public void LoadLog()
        {
            InputOutput.LoadLogFromFile();
        }

        /// <summary>
        /// Retorna un string masivo con todos los mensajes que posee el log.
        /// </summary>
        /// <returns>String compuesto de la totalidad de los elementos en su interior.</returns>
        public string FuseAllMessages()
        {
            string finalString = "";

            for (int i = 0; i < log.Count; i++)
                finalString += log[i];

            return finalString;
        }
    }
}
