import java.time.LocalTime;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

/*/
*	Clase orientada a manejar los metadatos hora y fecha obtenidos del sistema.
*	@Author: Carlos Henriquez.
/*/
public class DateTimeHandler
{
	/*/
	Obtener la hora del sistema, que es retornada con el formato [Hora, Minuto, Segundo].
	@return array de int de largo 3, que representa el formato descrito anteriormente.
	/*/
	public static int[] getTime()
	{
		LocalTime time = LocalTime.now();
		String stringTime = time.format(DateTimeFormatter.ISO_LOCAL_TIME);

		int hour = Integer.parseInt(stringTime.substring(0, 2));
		int minute = Integer.parseInt(stringTime.substring(3, 5));
		int second = Integer.parseInt(stringTime.substring(6, 8));

		int[] finalTime = {hour, minute, second};

		return finalTime;
	}


	/*/
	Obtener la fecha del sistema, que es retornada con el formato [Dia, Mes, Ciclo de 365 dias].
	@return array de int de largo 3, que representa el formato descrito anteriormente.
	/*/
	public static int[] getDate()
	{
		LocalDate date = LocalDate.now();
		String stringDate = date.format(DateTimeFormatter.ISO_LOCAL_DATE);

		int year = Integer.parseInt(stringDate.substring(0, 4));
		int month = Integer.parseInt(stringDate.substring(5, 7));
		int day = Integer.parseInt(stringDate.substring(8, 10));

		int[] finalDate = {day, month, year};

		return finalDate;
	}

	/*/
	Obtener la fecha del sistema, retornada en formato String.
	@return String con la fecha obtenida del sistema.
	/*/
	public static String getStringDate()
	{
		int[] date = getDate();

		String day = Integer.toString(date[0]);
		String month = Integer.toString(date[1]);
		String year = Integer.toString(date[2]);

		String finalDate = day + "-" + month + "-" + year;
		return finalDate;
	}

	/*/
	Obtener la fecha del sistema, retornada en formato String.
	@param splitter marca con que caracter se separaran la hora y los minutos.
	@return String con la fecha obtenida del sistema.
	/*/

	public static String getStringTime(char splitter)
	{
		int[] time = getTime();

		String hour = Integer.toString(time[0]);
		String minute = Integer.toString(time[1]);

		String finalTime = hour + splitter + minute;
		return finalTime;
	}
}