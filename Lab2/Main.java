public class Main
{
	public static void main(String[] args) throws java.io.FileNotFoundException, java.io.IOException
	{

		String input;
		boolean command;
		int commandSelection;
		String filename;
		boolean chatting = false;

		int autoRatingResult;
		int userRatingResult;

		int cash;
		Usuario user = new Usuario(0);

		Log log = new Log();

		Chatbot shopKeeper = new Chatbot(0);


		System.out.println("Bienvenido a la tienda de Lezalith. Esta tienda se situa en un mundo medieval fantastico, donde abundan criaturas\nmiticas como dragones o elfos.\nEsta tienda es regentada por Lezalith, una joven emprendedora de 20 primaveras; y su hermana menor, Roxane, de 16.\n\n");
		

		while(true)
		{
			input = InputOutput.getEntry();

			if (input.equals(""))
				continue;

			command = InputOutput.decodeUserEntry(input);

			if (command)
			{
				commandSelection = InputOutput.identifyCommand(input);

				// BeginDialog
				if (commandSelection == 1)
				{
					if (chatting)
					{
						shopKeeper.sayGoodbye(log);
						log.insertEndingMarker();
					}

					cash = InputOutput.getUserMoney();
					user.changeCurrency(cash);

					chatting = true;
					shopKeeper = new Chatbot(InputOutput.getSeed(input));

					log.insertStartingMarker();
					shopKeeper.sayHello(log);
				}

				// EndDialog
				if (commandSelection == 2)
				{
					if (chatting == false)
					{
						System.out.println("Error: No hay una conversacion en curso en estos momentos. Por favor, ejecute un comando coherente.");
						continue;
					}
					
					chatting = false;
					shopKeeper.sayGoodbye(log);
					log.insertEndingMarker();
				}

				// SaveLog
				if (commandSelection == 3)
				{
					filename = DateTimeHandler.getStringDate() + "_" + DateTimeHandler.getStringTime('-') + ".log";
					log.writeLog(filename);
					
				}

				// LoadLog
				if (commandSelection == 4)
				{
					filename = InputOutput.getFilename(input);
					log.loadLog(filename);

					if (log.length() == 0)
					{
						chatting = false;
						continue;
					}

					if (log.obtain(log.length() - 1).charAt(1) == '#')
						chatting = false;

					else
						chatting = true;
					
				}

				// Rate
				if (commandSelection == 5)
				{
					if (chatting == true)
					{
						System.out.println("Error: No es posible efectuar una evaluacion si es que hay una conversacion en curso. Terminela primero usando el comando !endDialog");
						continue;
					}

					autoRatingResult = Integer.parseInt(input.split(" ")[1]);
					userRatingResult = Integer.parseInt(input.split(" ")[2]);

					InputOutput.exportRatingResults(userRatingResult, autoRatingResult);
					
				}

				// Quit
				if (commandSelection == 6)
				{
					break;	
				}

				// Help
				if (commandSelection == 7)
					System.out.println("Comandos disponibles:\n!beginDialog <seed>: Inicia una conversacion con un chatbot cuya personalidad es generada por la semilla ingresada, la semilla predeterminada es 0, y sera cargada en caso de omitirse.\n!endDialog: Finaliza un dialogo, que es cerrado con un mensaje de despedida del chatbot.\n!saveLog: Guarda los progresos de la conversacion actual en un documento de texto, cuyo nombre es determinado por la fecha y hora de emision.\n!loadLog <nombre del archivo>: Carga los progresos de una conversacion previa, guardada en un log con el formato que utiliza el comando !saveLog.\n!rate: Por determinar.\n!help: Muestra los comandos disponibles para el usuario.\n!checkWallet: Muestra la cantidad de dinero disponible.\n!quit: Cierra el programa.");

				// Check Wallet
				if (commandSelection == 8)
				{
					System.out.print("Su cantidad de dinero actual es de: ");
					System.out.println(user.getCash());
				}

				// Error
				if (commandSelection == 9)
					continue;


			}


			else
			{
				// Esta seccion solo se ejecuta si hay una conversacion en curso.
				if (chatting == false)
				{
					System.out.println("Actualmente no se esta sosteniendo ninguna conversacion.\nPuede iniciar una con el comando !beginDialog. !help le proporcionara informacion acerca de los comandos disponibles.");
					continue;
				}

				log.addInputToLog(input);
				shopKeeper.selectMessage(input, log, user);

			}

			
		}
	}
}