import java.util.ArrayList;

class Log
{
	 ArrayList<String> log;

	 public Log()
	 {
	 	log = new ArrayList<String>();
	 }

	 public void appendMessage(String message)
	 {
	 	log.add(message);
	 }

	 public void writeLog(String filename) throws java.io.FileNotFoundException
	 {
	 	InputOutput.writeLogInFile(filename, log);
	 }

	 public void loadLog(String filename) throws java.io.FileNotFoundException, java.io.IOException
	 {
	 	log.clear();
	 	InputOutput.loadLogFromFile(filename, log);
	 }

	 public int length()
	 {
	 	int length = log.size();
	 	return length;
	 }

	 public String obtain(int index)
	 {
	 	String element = log.get(index);
	 	return element;
	 }

	 public void addInputToLog(String input)
	 {
	 	String finalMessage;

	 	finalMessage = DateTimeHandler.getStringTime(':') + " | " + "Viajero" + ": " + input;
	 	System.out.println(finalMessage);
	 	log.add(finalMessage);
	 }

	 public void insertStartingMarker()
	 {
	 	String marker;

	 	marker = "# " + DateTimeHandler.getStringDate() + " / " + DateTimeHandler.getStringTime(':') + " - Inicia una nueva conversacion.";

	 	log.add(marker);
	 }

	 public void insertEndingMarker()
	 {
	 	String marker;

	 	marker = "## " + DateTimeHandler.getStringDate() + " / " + DateTimeHandler.getStringTime(':') + " - Fin de la conversacion.";

	 	log.add(marker);
	 }
}