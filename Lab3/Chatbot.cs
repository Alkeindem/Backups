using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot
{
    /// <summary>
    /// Esta clase contiene los parametros y funciones relacionados con los mensajes enviados por el chatbot.
    /// </summary>
    public class Chatbot
    {
        public String name;

        private String genericGreeting;
        private String morningGreeting;
        private String afternoonGreeting;
        private String eveningGreeting;

        private String[] buyingResponses;
        private String merchandise;

        private String[] articlesInfo;
        private String[] buyingArticles;

        private String notEnough;

        private String sellingResponse;

        private String[] rumours;

        private String[] misheard;

        private String farewell;

        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="seed">Factor randomizador.</param>
        public Chatbot(int seed)
        {
            // La mercancia es independiente de la personalidad del chatbot.
            merchandise = "                 Escudo Rubi: 1500 flurios \n                 Espadon Escarlata: 1750 flurios \n                 Tomo de Combustion Espontanea: 1000 flurios \n                 Piedra Draconica Celeste: 2500 flurios \n                 Pocion de recuperacion: 250 flurios.\n                 Si quieres saber algo acerca de algun articulo solo tienes que preguntarlo.\n";

            // Lezalith - Personalidad: Servicial y carismatica.
            if ((seed % 2) == 0)
            {
                name = "Lezalith";

                genericGreeting = "Hola aventurero, en que puedo ayudarte?";
                morningGreeting = "El sol despunta y tu preparandote para la batalla. Compra algo para que no tengas problemas a lo largo del dia!";
                afternoonGreeting = "Buenas tardes aventurero, necesitas equipamiento?";
                eveningGreeting = "Buenas noches aventurero; ya estamos por cerrar, pero siempre puedo atender a una persona mas. Que necesitas?";

                buyingResponses = new String[2];
                buyingResponses[0] = "Conque quieres comprar algo huh? Te mostrare lo que tenemos a disponible:";
                buyingResponses[1] = "Excelente, mira estos articulos por favor.";


                articlesInfo = new String[5];

                articlesInfo[0] = "El Escudo Rubi es un escudo emblematico de nuestro pais. Su leyenda se remonta a los origenes de la ciudad de Flur. No entrare en detalles, pero la leyenda cuenta que un viajero repelio una horda completa de esqueletos y que su escudo permanecio inmaculado tras semejante derroche de valentia.\nEl escudo rubi no esta creado a partir de rubi, contrario a lo que se piensa popularmente, sino de piedra draconica rojiza que se asemeja a los rubies.\nEsta cualidad le permite repeler incluso las llamaradas de algunas criaturas sin que el portador sufra herida alguna.";
                articlesInfo[1] = "El Espadon Escarlata que vendemos aqui es una replica muy precisa del espadon descrito en la leyenda de Ruhium, el Sanguinario. Se cuenta que este hombre, de origenes inciertos, llego un dia a Flur con la intencion de arrasarla tal cual un vil bandido.\n Pero basto con ver los hermosos prados que rodean la ciudad, y oir el melodico fluir de los riachuelos cercanos para que se esfumara cualquier pensamiento que no fuese vivir y proteger estos lares.\n Su espadon, una hoja descomunal, que habia adquirido un color escarlata en su hoja por tanta sangre que un dia derramo; se convirtio en un simbolo de quietud y paz mental para nosotros.";
                articlesInfo[2] = "El Tomo de Combustion Espontanea es uno de los hechizos basicos que aprenden los estudiantes de la escuela magica de la piromancia. A pesar de ser un hechizo de primerizos, es una herramienta muy util para todo el mundo. Requiere poco poder magico y solo se compone de tres versos, pero su efectividad es aterradora. Consiste en un hechizo capaz de prender en llamas a cualquier objetivo que este en tu campo de vision y en un radio de 15 metros. El objetivo continuara ardiendo hasta que su cuerpo de reduzca a cenizas, pero el fuego se disipara si pierdes al objetivo de vista o si las condiciones ambientales no permitan la combustion.";
                articlesInfo[3] = "Los dragones poseen ciertas cualidades especiales que el resto de las especies no. Estas cualidades dependen del dragon, y usualmente puede distinguirseles por el color de las escamas. A medida que los dragones crecen, sus cuerpos producen una cristalizacion de la energia vital que irradia de su cuerpo. Cada cierto tiempo, los dragones expulsan de su cuerpo esta cristalizacion a modo de desecho y es lo que nosotros conocemos por piedra draconica. El color de la piedra coincide con el de las escamas del dragon que sintetizo esa piedra, y la piedra posee las mismas cualidades extraordinarias que este ultimo. En particular, la piedra de dragon celeste es una gema que expulsa un torrente de rayos a voluntad; pero requiere que su portador la cargue con energia magica para desatar su terrible poder.";
                articlesInfo[4] = "La vieja y confiable pocion de recuperacion ha sacado de apuros tanto a principiantes como a expertos del mundo de las armas. Esta compuesta de muchos ingredientes regenerativos que apresuran enormemente tu regeneracion natural. ";


                buyingArticles = new String[5];
                buyingArticles[0] = "Compraras un Escudo Rubi? Muy bien, son 1500 flurios. Tus enemigos flaquearan en voluntad al ver que ninguno de sus ataques lograra atravesar tu defensa.";
                buyingArticles[1] = "Iras por el Espadon Escarlata, huh? Buena eleccion, son 1750 flurios. Siento lastima por esas pobres bestias que se atrevan a enfrentarte.";
                buyingArticles[2] = "Te convencio el Tomo Magico? El precio es de 1000 flurios. Una ganga, no crees?. Tus enemigos no sabran que los hizo arder en llamas.";
                buyingArticles[3] = "Son 2500 flurios por la Piedra Draconica. Una vez que logres cargarla, desataras un cataclismo en el campo de batalla. Recuerda usarla con prudencia.";
                buyingArticles[4] = "Son 250 flurios por la Pocion. Hay que ser precavidos, verdad?";

                notEnough = "Al parecer no tiene suficiente dinero. Por favor, trate de comprar algo que pueda permitirse con su dinero";

                sellingResponse = "Lo siento, en esta tienda no compramos a nuestros clientes. La tienda vecina se arruino un dia que llego un aventurero con 6 millones de huesos de monstruos. El pobre vendedor tuvo que comprarselos todos, y todo por seguir esa ridicula politica.";

                rumours = new String[3];
                rumours[0] = "La expedicion que salio hace unas semanas en busqueda del dragon maligno no ha vuelto aun. Temo que hayan fracasado en su objetivo.";
                rumours[1] = "La caravana que suple mis articulos lleva 4 dias de retraso. Los habran asaltado goblins o algo?.";
                rumours[2] = "La ciudad esta muy ajetreada estos dias. Todos temen un asalto nocturno de parte de los dragones anti-pactianos.";

                misheard = new String[3];
                misheard[0] = "Lo siento, creo que no puedo comprender algunas de las palabras que usas viajero. Podrias reformularme eso que has dicho?";
                misheard[1] = "Creo que no he escuchado bien, que has dicho?";
                misheard[2] = "Lamento no conocer el lenguaje de un modo tan habil como vos, pero es necesario que te rebajes a mi nivel para que nos entendamos.\nPodrias describir eso con palabras mas cercanas a mi entendimiento?";

                farewell = "Buena suerte, en realidad no la necesitas porque te has equipado aqui hahaha.";
            }

            // Roxane - Personalidad: Agresiva y perezosa.

            else
            {

                name = "Roxane";

                genericGreeting = "*suspiro* Hola aventurero, echale el ojo a las existencias y avisame cuando vayas a comprar algo, si?";
                morningGreeting = "Buenos dias aventurero. No te sientes somnoliento? Deberias volver a tu cama y dejarme dormir.";
                afternoonGreeting = "Buenas tardes, date una vuelta por la tienda y llevate algo, quieres?";
                eveningGreeting = "Ya esta oscureciendo. Apresurate en comprar o te dejare dentro.";

                buyingResponses = new String[2];
                buyingResponses[0] = "Esta bien. Puedes escoger cualquier objeto de entre los que aqui se encuentran: ";
                buyingResponses[1] = "Si quieres comprar tendras que conformarte con lo que tenemos. Hay problemas en las rutas comerciales, asi que no hay mucha variedad.";

                articlesInfo = new String[5];

                articlesInfo[0] = "El Escudo Rubi que aqui vendemos es una replica exacta del legendario escudo de la famosa epica narrada todas las noches en los bares de Flur. El escudo que portaba el defensor de Flur salvaguardo a nuestro heroe de los infinitos golpes de las furibundas hordas de monstruos que azotaban nuestra ciudad.\nNo pienses mal de el por ser una replica. Podria ser mejor que el original, pues posee propiedades magicas que lo vuelven aun mas impenetrable para cualquier ataque que desafie la fortaleza de este escudo.";
                articlesInfo[1] = "Ruhium, el Sanguinario, blandio una espada como esta hace decadas. Era un hombre temido por todo el mundo que, enamorado de la belleza de nuestra ciudad y la quietud de sus alrededores, hizo de este lugar su hogar y lo defendio de los muchos invasores que asediaron Flur en esa epoca.\nVer el espadon de Ruhium en batalla, era como ver la hoz de la muerte sesgando las vidas de sus adversarios. Eso no ha cambiado hasta el dia de hoy, pues nuestro Espadon Escarlata no tiene motivos para palidecer ante su modelo: El espadon de Rihium.";
                articlesInfo[2] = "Ese tomo es el que estudian los principiantes de la piromancia. Puedes comprarlo si te apetece, pero a tu edad tal vez debas practicarlo en privado. Los estudiantes se reiran de ti si te ven lanzando ese hechizo tan simple. ";
                articlesInfo[3] = "Mi hermana explica esto con mayor precision, pero en pocas palabras, esta piedra puede almacenar grandes cantidades de energia magica y liberarla en forma de rayos. Se obtiene a partir de la cristalizacion magica del dragon de escamas celestes.";
                articlesInfo[4] = "No hay mucho que explicar, verdad? El nombre lo dice todo. Ultimamente hemos vendido muchas de estas a algunos jovenes. Tal vez pueden generar adiccion...";

                buyingArticles = new String[5];
                buyingArticles[0] = "Te llevas el Escudo Rubi? Son 1500 flurios a cambio de una defensa inexpugnable. Una ganga, no?";
                buyingArticles[1] = "Compraras el Espadon? Bueno, desde hoy no hay enemigo que pueda resistir tu furia. Pobres bestias. Son 1750 flurios";
                buyingArticles[2] = "Quieres iniciarte en el mundo de la magia? Una vez que domines los conocimientos arcanos, bastara una palabra de tus labios para que cualquier enemigo caiga a tus pies. Son 1000 flurios, por favor.";
                buyingArticles[3] = "Esa piedra de costara 2500 flurios. No se para que la quieres si no pareces poder cargarla de energia magica. Pero bueno, eres libre de desperdiciar tu dinero.";
                buyingArticles[4] = "Son 250 flurios por la pocion. Estoy pensando seriamente en subir el precio de estas cosas, dada la alta demanda ultimamente, asi que compra todas las que puedas ahora que estan baratas.";

                notEnough = "Sin dinero, no hay objeto; asi de simple. Compra otro objeto o vete.";

                sellingResponse = "Quieres llevarnos a la bancarrota? No se en que mundo las tiendas podrian comprar toda la basura que traen los aventureros desde afuera de la ciudad.";

                rumours = new String[3];
                rumours[0] = "Con el pacto de proteccion mutua entre humanos y dragones roto, ya no hay nada que garantice nuestra seguridad. Es mas, los mismos dragones anti pactianos son una amenaza presente.";
                rumours[1] = "Al parecer, los estudiantes de las escuelas magicas ya no pueden salir al bosque a buscar ingredientes para pociones. Ultimamente las bestias abundan fuera de la ciudad.";
                rumours[2] = "El explorador en jefe del gremio ha organizado una nueva expedicion hacia el pico sagrado. Dicen que un dragon muy sabio vive alli, y podria ayudarnos a entender porque los dragones han deshecho el pacto de proteccion mutua.";

                misheard = new String[3];
                misheard[0] = "Que palabras mas raras utilizas, no te he entendido nada.";
                misheard[1] = "Crees que podrias decirme eso en palabras normales?";
                misheard[2] = "...";

                farewell = "Adios, aventurero. Sal en silencio por favor, intentare seguir durmiendo.";
            }
        }

        /// <summary>
        /// Obtener el saludo pertinente utilizando factores relevantes como la hora.
        /// </summary>
        /// <returns>String con el saludo correspondiente.</returns>
        private string SelectGreeting()
        {
            if ((Utilities.RandInt() % 2) == 0)
                return this.genericGreeting;

            int[] time = new int[3];
            time = DateTimeHandler.GetTime();

            if ((time[0] >= 6) && (time[0] < 12))
                return this.morningGreeting;

            else if ((time[0] >= 12) && (time[0] < 20))
                return this.afternoonGreeting;

            else
                return this.eveningGreeting;
        }

        /// <summary>
        /// Acopla al saludo la timestamp caracteristica de los mensajes.
        /// </summary>
        /// <returns>String con el saludo.</returns>
        public string SayHello()
        {
            string greeting = this.SelectGreeting();
            string finalMessage = DateTimeHandler.GetString("time") + " | " + this.name + ": " + greeting;

            return finalMessage;
        }

        /// <summary>
        /// Acopla al mensaje de despedida la timestamp caracteristica de los mensajes.
        /// </summary>
        /// <returns>String con el despido.</returns>
        public string SayGoodbye()
        {
            string finalMessage = DateTimeHandler.GetString("time") + " | " + this.name + ": " + farewell;
            return finalMessage;
        }

        /// <summary>
        /// Selecciona el mensaje respuesta en base a la entrada del usuario.
        /// </summary>
        /// <param name="input">Mensaje ingresado por el usuario</param>
        /// <returns>String con la respuesta del chatbot.</returns>
        public string SelectMessage(string input)
        {
            string[] keywordSet1 = { "comprar", "escudo" };
            string[] keywordSet2 = { "comprar", "espadon" };
            string[] keywordSet3 = { "comprar", "tomo" };
            string[] keywordSet4 = { "comprar", "piedra" };
            string[] keywordSet5 = { "comprar", "pocion" };
            string[] keywordSet6 = { "comprar" };

            string[] keywordSet7 = { "hablame", "escudo" };
            string[] keywordSet8 = { "hablame", "espadon" };
            string[] keywordSet9 = { "hablame", "tomo" };
            string[] keywordSet10 = { "hablame", "piedra" };
            string[] keywordSet11 = { "hablame", "pocion" };

            string[] keywordSet12 = { "vender" };
            string[] keywordSet13 = { "escuchado", "interesante" };

            string finalMessage;

            if (Utilities.AreKeywordsInInput(keywordSet1, input))
            {
                if (MainForm.user.cashIsEnough(1500))
                {
                    finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingArticles[0];
                    MainForm.user.diminishCurrency(1500);
                }

                else
                    finalMessage = notEnough;

                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet2, input))
            {
                if (MainForm.user.cashIsEnough(1750))
                {
                    finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingArticles[1];
                    MainForm.user.diminishCurrency(1750);
                }

                else
                    finalMessage = notEnough;

                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet3, input))
            {
                if (MainForm.user.cashIsEnough(1000))
                {
                    finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingArticles[2];
                    MainForm.user.diminishCurrency(1000);
                }

                else
                    finalMessage = notEnough;

                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet4, input))
            {
                if (MainForm.user.cashIsEnough(2500))
                {
                    finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingArticles[3];
                    MainForm.user.diminishCurrency(2500);
                }

                else
                    finalMessage = notEnough;

                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet5, input))
            {
                if (MainForm.user.cashIsEnough(250))
                {
                    finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingArticles[4];
                    MainForm.user.diminishCurrency(250);
                }

                else
                    finalMessage = notEnough;

                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet6, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + buyingResponses[Utilities.RandInt() % 2] + "\n" + merchandise;
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet7, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + articlesInfo[0];
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet8, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + articlesInfo[1];
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet9, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + articlesInfo[2];
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet10, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + articlesInfo[3];
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet11, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + articlesInfo[4];
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet12, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + this.sellingResponse;
                return finalMessage;
            }

            else if (Utilities.AreKeywordsInInput(keywordSet13, input))
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + rumours[Utilities.RandInt() % 3];
                return finalMessage;
            }

            else
            {
                finalMessage = DateTimeHandler.GetString("time") + " | " + name + ": " + misheard[Utilities.RandInt() % 3];
                return finalMessage;
            }
        }


    }
}
