using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    public class Usuario
    {
        private int cash;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="money">Cantidad de dinero inicial asignada a esta instancia de la clase.</param>
        public Usuario(int money)
        {
            if (money < 0)
                this.cash = 10000;

            else
                this.cash = money;
        }

        /// <summary>
        /// Obtener el valor cash actual.
        /// </summary>
        /// <returns>Cash actual.</returns>
        public int getCash()
        {
            return this.cash;
        }

        /// <summary>
        /// Disminuye el valor cash en una cantidad indicada
        /// </summary>
        /// <param name="value">Valor de decrecimiento del parametro cash.</param>
        public void diminishCurrency(int value)
        {
            this.cash = this.cash - value;
        }

        /// <summary>
        /// Discierne si el valor cash es mayor o igual que un valor de entrada, o no.
        /// </summary>
        /// <param name="value">Valor a comparar</param>
        /// <returns>Valor booleano resultado del analisis. true si cash es mayor o igual a la entrada; false en cualquier otro caso.</returns>
        public bool cashIsEnough(int value)
        {
            if (cash >= value)
                return true;

            return false;
        }

        /// <summary>
        /// Modificar el valor de cash.
        /// </summary>
        /// <param name="value">Valor nuevo para el parametro cash.</param>
        public void changeCurrency(int value)
        {
            this.cash = value;
        }

    }
}
