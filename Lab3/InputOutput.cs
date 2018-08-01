using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatbot
{
    class InputOutput
    {
        /// <summary>
        /// Crear un archivo de texto con el contenido del log actual en su interior.
        /// </summary>
        /// <param name="logContent"> array de strings con los mensajes del log.</param>
        public static void SaveLogInFile(string[] logContent)
        {
            string filename = "";
            StreamWriter writer;


            SaveFileDialog browser = new SaveFileDialog();
            browser.DefaultExt = ".txt";
            browser.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*;";
            browser.Title = "Save Log Window";
            DialogResult dr = browser.ShowDialog();

            if (dr == DialogResult.OK)
                filename = browser.FileName;

            if (filename != "")
            {
                writer = new StreamWriter(filename, false);

                foreach (string line in logContent)
                {
                    writer.Write(line);
                }

                writer.Close();
            }
        }

        /// <summary>
        /// Cargar en el log un contenido previamente guardado.
        /// </summary>
        public static void LoadLogFromFile()
        {
            string filename = "";
            MainForm.log.Clean();
            StreamReader reader;
            string line;

            OpenFileDialog browser = new OpenFileDialog();
            browser.DefaultExt = ".txt";
            browser.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*;";
            browser.Title = "Load Log Window";
            DialogResult dr = browser.ShowDialog();

            if (dr == DialogResult.OK)
                filename = browser.FileName;

            if (filename != "")
            {
                reader = new StreamReader(filename);

                while (((line = reader.ReadLine()) != null))
                {
                    MainForm.log.AppendMessage(line);
                }

                reader.Close();               
            }
        }

        /// <summary>
        /// Crear un archivo de texto (o actualizarlo) con la nota recien agregada.
        /// </summary>
        /// <param name="rate">Nota ingresada por el usuario.</param>
        public static void SaveRatings(int rate)
        {
            string path = Directory.GetCurrentDirectory() + "/ratings.txt";

            StreamWriter writer;

            if (File.Exists(path))
            {
                writer = new StreamWriter(path, true);
                writer.Write(" " + rate.ToString());
                writer.Close();
            }

            else
            {
                writer = new StreamWriter(path, false);
                writer.Write(rate);
                writer.Close();
            }
        }

        /// <summary>
        /// Obtiene las notas del archivo que las contiene.
        /// </summary>
        /// <returns>Array de enteros con las notas encontradas en el arhcivo. Si este no existe, se retorna un array donde el unico elemento es -1.</returns>
        public static int[] GetRatings()
        {
            int[] ratings;
            string[] stringRatings;
            string path = Directory.GetCurrentDirectory() + "/ratings.txt";
            StreamReader reader;
            string line;

            if (!File.Exists(path))
            {
                ratings = new int[1];
                ratings[0] = -1;
                return ratings;
            }

            reader = new StreamReader(path);

            line = reader.ReadLine();
            stringRatings = line.Split(' ');

            reader.Close();
            ratings = new int[stringRatings.Length];

            for (int i = 0; i < stringRatings.Length; i++)
            {
                ratings[i] = Int32.Parse(stringRatings[i]);
            }

            return ratings;
            
        }
    }
}
