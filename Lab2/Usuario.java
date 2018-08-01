class Usuario
{
	private int cash;

	/*/
	Constructor de la clase
	@param money Cantidad de dinero que sera asignada a la instancia de Usuario a construir.
	/*/
	public Usuario(int money)
	{
		if (money < 0)
			cash = 10000;

		else
			cash = money;
	}

	/*/
	Setter: Asigna un nuevo valor al parametro cash.
	@param value Nuevo valor a asignar.
	/*/
	public void changeCurrency(int value)
	{
		cash = value;
	}

	/*/
	Getter: Obtiene el valor actual del parametro cash.
	@return Valor actual del parametro cash.
	/*/
	public int getCash()
	{
		return cash;
	}

	/*/
	Reduce el valor de cash en la instancia.
	@param value Indica la cantidad en la que se desea reducir el monto.
	/*/
	public void diminishCurrency(int value)
	{
		cash = cash - value;
	}

	/*/
	Analiza si es que cash es mayor o igual que un valor dado.
	@param value Valor a comprar con cash.
	/*/
	public boolean cashIsEnough(int value)
	{
		if (cash >= value)
			return true;

		return false;
	}

	
}