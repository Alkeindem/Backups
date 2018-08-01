/*/
*	Clase orientada a albergar las funciones que el programa utiliza, pero que no califica para entrar en ninguna otra clase.
*	@Author Carlos Henriquez.
/*/
class Utilities
{
	/*/
	Imprimir por pantalla el arreglo ingresado como entrada.
	@param array Arreglo a imprimir por pantalla
	/*/
	public static void printIntArray(int[] array)
	{
		System.out.print("[");
		System.out.print(array[0]);

		for(int i = 1; i < array.length; i++)
		{
			System.out.print(", ");
			System.out.print(array[i]);
		}

		System.out.println("]");

	}

	/*/
	Generar un numero aleatorio entero.
	@return Numero entero aleatorio.
	/*/
	public static int randInt()
	{
		int number = (int) (Math.random() * 1000);
		return number;
	}

	/*/
	Analizar si una palabra dad existe en un arreglo de palabras.
	@param word String que corresponde a la palabra a buscar
	@param array Arreglo de Strings que contienen palabras entre las que podria estar el parametro word.
	@return Valor booleano que indica si la palabra esta o no en el arreglo. 
	/*/
	public static boolean isWordInArray(String word, String[] array)
	{
		for (String element : array)
		{
			if (element.equals(word))
				return true;
		}

		return false;
	}

	/*/
	Analizar si un conjunto de palabras se encuentran en un string mas grande.
	@param keywords Arreglo que contiene un conjunto de palabras.
	@param input String que contiene una frase que podria o no contener las palabras del parametro keywords.
	@return Valor booleano que indica si las palabras clave se hayan o no en el parametro input.
	/*/
	public static boolean areKeywordsInInput(String[] keywords, String input)
	{
		for (String singleKeyword : keywords)
		{
			if (!isWordInArray(singleKeyword, input.split(" ")))
				return false;
		}

		return true;
	}
}