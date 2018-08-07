import java.util.ArrayList;

/*/
*	Clase destinada a almacenar los mensajes intercambiados entre el chatbot y el usuario.
*	@author; Carlos Henriquez Rojas.
/*/

class Log
{
	 ArrayList<String> log;

	 // Constructor de la clase.
	 public Log()
	 {
	 	log = new ArrayList<String>();
	 }

	 // Agregar un string al Log.
	 public void appendMessage(String message)
	 {
	 	log.add(message);
	 }

	 // Crear un archivo que contiene la informacion que el Log guarda,
	 public void writeLog(String filename) throws java.io.FileNotFoundException
	 {
	 	InputOutput.writeLogInFile(filename, log);
	 }

	 // Carga en el Log la informacion contenida en un archivo escrito con el formato utilizado por writeLog().
	 public void loadLog(String filename) throws java.io.FileNotFoundException, java.io.IOException
	 {
	 	log.clear();
	 	InputOutput.loadLogFromFile(filename, log);
	 }

	 // Obtener el largo del Log.
	 // @return Largo actual del Log.
	 public int length()
	 {
	 	int length = log.size();
	 	return length;
	 }

	 // Obtener un mensaje del Log.
	 // @param index Integer que indica cual mensaje se desea obtener.
	 // @return Mensaje deseado.
	 public String obtain(int index)
	 {
	 	String element = log.get(index);
	 	return element;
	 }

	 // Agregar mensaje del usuario al Log. Al mensaje se le acoplan los aditamentos necesarios para cumplir con el formato.
	 // @param input String con el mensaje del usuario.
	 public void addInputToLog(String input)
	 {
	 	String finalMessage;

	 	finalMessage = DateTimeHandler.getStringTime(':') + " | " + "Viajero" + ": " + input;
	 	System.out.println(finalMessage);
	 	log.add(finalMessage);
	 }

	 // Agrega al Log un "mensaje" que marca el inicio de una nueva conversacion.
	 public void insertStartingMarker()
	 {
	 	String marker;

	 	marker = "# " + DateTimeHandler.getStringDate() + " / " + DateTimeHandler.getStringTime(':') + " - Inicia una nueva conversacion.";

	 	log.add(marker);
	 }

	 // Agrega al Log un "mensaje" que marca el fin de una nueva conversacion.
	 public void insertEndingMarker()
	 {
	 	String marker;

	 	marker = "## " + DateTimeHandler.getStringDate() + " / " + DateTimeHandler.getStringTime(':') + " - Fin de la conversacion.";

	 	log.add(marker);
	 }
}