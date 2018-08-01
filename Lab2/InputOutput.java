import java.util.Scanner;
import java.io.*;
import java.util.ArrayList;

/*/
*	Clase destinada a manejar la lectura y escritura de archivos, asi como el procesado de la informacion extraida de ellos.
*	Tambien es la encargada de recibir mensajes por consola, mas no es quien los envia.
*	@Author: Carlos Henriquez.
/*/
class InputOutput
{
	public static Scanner reader = new Scanner(System.in);

	/*/
	Recibir una entrada ingresada por el usuario via consola.
	@return string con el mensaje escrito por el usuario.
	/*/
	public static String getEntry()
	{
		String input = reader.nextLine();
		return input;
	}

	/*/
	Concluir si la entrada ingresada por el usuario es un comando o un mensaje.
	@param input entrada del usuario en forma de string.
	@return valor booleano que discierne si la entrada es un comando (true: si ; false: no).
	/*/
	public static boolean decodeUserEntry(String input)
	{
		if (input.charAt(0) == '!')
			return true;

		return false;
	}

	/*/
	Identificar cual comando fue ingresado.
	@param input comando ingresado previamente por el usuario via consola.
	@return numero entero que simboliza algun comando en especifico, o bien, la ausencia de uno.
	/*/
	public static int identifyCommand(String input)
	{
		char keyLetter = input.charAt(1);

		if (keyLetter == 'b')		// Caso 1: beginDialog.
			return 1;

		else if (keyLetter == 'e')     // Caso 2: endDialog.
			return 2;

		else if (keyLetter == 's')	   // Caso 3: saveLog.
			return 3;

		else if (keyLetter == 'l')		// Caso 4: loadLog.
			return 4;

		else if (keyLetter == 'r')		// Caso 5: rate.
			return 5;

		else if (keyLetter == 'q')		// Caso 6: quit.
			return 6;

		else if (keyLetter == 'h')		// Caso 7: help
			return 7;

		else if (keyLetter == 'c')		// Caso 8: checkWalle
			return 8;

		else
		{
			System.out.println("Error: comando desconocido. Intentelo nuevamente");
			return 9;
		}
	}

	/*/
	Aisla la seed en el comando !beginDialog, que es posteriormente identificada.
	@param input Entrada ingresada por el usuario en forma de String.
	@return valor entero de la seed ingresada por el usuario. En caso de omision, se retorna el valor predeterminado (0).
	/*/
	public static int getSeed(String input)
	{
		int seed;
		String stringSeed;

		try
		{
			stringSeed = input.split(" ")[1];
			seed = Integer.parseInt(stringSeed);
		}

		catch (java.lang.IndexOutOfBoundsException erron)
		{
			return 0;
		}

		return seed;
	}

	/*/
	Aisla y retorna el nombre del archivo especificado por el comando !loadLog.
	@param input Entrada ingresada por el usuario en forma de String.
	@return string que corresponde al nombre del archivo.
	/*/
	public static String getFilename(String input)
	{
		String filename = "";

		try
		{
			filename = input.split(" ")[1];
		}

		catch (java.lang.IndexOutOfBoundsException erron)
		{
			System.out.println("Error: El nombre ingresado no se corresponde con el de ningun archivo en el directorio respectivo.");
			System.exit(1);
		}

		return filename;
	}

	/*/
	Crea un nuevo archivo de texto, en el que se guarda el contenido del log actual.
	@param filename String que contiene el nombre que llevara el archivo a crear.
	@param log historial de la conversacion actual, es el contenido a guardar en el archivo.
	/*/
	public static void writeLogInFile(String filename, ArrayList<String> log) throws FileNotFoundException
	{

		PrintWriter writer = new PrintWriter(filename);

		for (int i = 0; i < log.size(); i++)
			writer.println(log.get(i));

		System.out.println("Archivo guardado con exito");
		writer.close();
	}

	/*/
	Cargar log desde un archivo de texto creado previamente por el comando !writeLog.
	@param filename String que contienen el nombre del archivo a abrir.
	@param log Arreglo que cargara en sus adentros el contenido del archivo.
	/*/
	public static void loadLogFromFile(String filename, ArrayList<String> log) throws java.io.IOException
	{
		BufferedReader reader = null;

		try
		{
			reader = new BufferedReader(new FileReader(filename));
		}

		catch (FileNotFoundException erron)
		{
			System.out.println("Error: Nombre ingresado no valido, el archivo no existe.");
			return;
		}

		String tempLine;

		while((tempLine = reader.readLine()) != null)
		{
			log.add(tempLine);
		}

		System.out.println("Archivo cargado con exito.\n");
		reader.close();
	}

	/*/
	Recibir una calificacion de parte del usuario, e informarle acerca de la escala de evaluacion.
	@return nota recibida en forma de entero.
	/*/
	public static int getUserRating()
	{
		System.out.println("Ingrese la calificacion que asigna al chatbot y a usted mismo durante su ultima conversacion. Donde 1 es la calificacion minima, 5 la maxima; y 0 simboliza que no es posible realizar una evaluacion.");
		System.out.println("Al ingresar las calificaciones, ingrese ambas separadas por un espacio; donde la primera nota corresponde a la nota del usuario y la segunda a la nota del chatbot.");
		int rateValue = reader.nextInt();
		return rateValue;
	}

	/*/
	Recibir la cantidad de dinero con la que el usuario desea contar.
	@return Cantidad de dinero especificada por el usuario en forma de entero.
	/*/
	public static int getUserMoney()
	{
		System.out.println("Antes de comenzar, por favor, indique la cantidad de dinero con la que desea contar.");
		System.out.print("Flurios: ");

		int cash = reader.nextInt();
		return cash;
	}

	/*/
	Crea o actualiza un archivo llamado "ratings.txt" con una nueva calificacion de parte del usuario.
	@param userRate nota asociada al usuario.
	@param autoRate nota asociada al chatbot.
	/*/
	public static void exportRatingResults(int userRate, int autoRate) throws FileNotFoundException
	{
		File file = new File("ratings.txt");
		boolean writePrologue = false;

		if (!(file.exists()))
		{
			writePrologue = true;
		}

		PrintWriter writer = new PrintWriter("ratings.txt");

		if (writePrologue)
			writer.println("Usuario / Chatbot");

		writer.println(Integer.toString(userRate) + " / " + Integer.toString(autoRate));

		writer.close();
	}
}