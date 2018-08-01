namespace Chatbot
{
    /// <summary>
    /// Esta clase guarda en su interior la parte mas importante de la ventana principal de la interfaz grafica.
    /// Esta consiste en los contenedores y controladores, ademas de otras funciones personalizadas que permiten el correcto
    /// funcionamiento del chatbot.
    /// </summary>
    partial class MainForm
    {
        public static int cash = 0;
        public static int seed = 0;
        public static int rate = 0;

        public static Log log = new Log();
        public static Usuario user = new Usuario(0);
        public static Chatbot shopKeeper = new Chatbot(0);
        private bool chatting = false;

        #region Codigo generado automaticamente por la IDE Visual Studio
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Start.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void StartButtonCallback(object sender, System.EventArgs e)
        {
            string tempMessage;

            Popup popup = new Popup();
            var dialogResult = popup.ShowDialog();

            if (chatting)
            {
                tempMessage = shopKeeper.SayGoodbye() + "\n";
                richTextBox1.Text += tempMessage;
                log.AppendMessage(tempMessage);

                tempMessage = "\n## " + DateTimeHandler.GetString("date") + " / " + DateTimeHandler.GetString("time") + " - Fin de la conversacion.\n";
                richTextBox1.Text += "\n" + tempMessage;
                log.AppendMessage(tempMessage);
            }

            chatting = true;
            shopKeeper = new Chatbot(seed);
            user = new Usuario(cash);


            this.richTextBox1.Clear();

            tempMessage = tempMessage = "# " + DateTimeHandler.GetString("date") + " / " + DateTimeHandler.GetString("time") + " - Inicia una nueva conversacion.\n\n";
            this.richTextBox1.Text = tempMessage;
            log.AppendMessage(tempMessage);


            tempMessage = shopKeeper.SayHello() + "\n";
            this.richTextBox1.Text += tempMessage;
            log.AppendMessage(tempMessage);
        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton End.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void EndButtonCallback(object sender, System.EventArgs e)
        {
            if (chatting == false)
            {
                richTextBox1.Text += "No hay una conversacion en curso.\n";
                return;
            }

            string tempMessage;

            tempMessage = shopKeeper.SayGoodbye() + "\n";
            richTextBox1.Text += tempMessage;
            log.AppendMessage(tempMessage);

            tempMessage = "\n## " + DateTimeHandler.GetString("date") + " / " + DateTimeHandler.GetString("time") + " - Fin de la conversacion.\n";
            richTextBox1.Text += tempMessage;
            log.AppendMessage(tempMessage);

            chatting = false;
        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Save Log.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void SaveButtonCallback(object sender, System.EventArgs e)
        {
            log.WriteLog();
        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Load Log.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void LoadButtonCallback(object sender, System.EventArgs e)
        {
            log.LoadLog();

            if (log.Length() == 0)
            {
                chatting = false;
                return;
            }

            richTextBox1.Text = "";

            for (int i = 0; i < log.Length(); i++)
            {
                richTextBox1.Text += log.Get(i);
                richTextBox1.Text += "\n";
            }

            System.Console.WriteLine(log.Length());

            

            if (log.Get(log.Length() - 1)[1] == '#')
                chatting = false;

            else
                chatting = true;
        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Send.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void SendButtonCallback(object sender, System.EventArgs e)
        {
            if (chatting == false)
            {
                richTextBox1.Text = "No es posible enviar mensajes si no hay una conversacion en curso";
                return;
            }

            string processedMessage = DateTimeHandler.GetString("time") + " | Aventurero: " + textBox1.Text + "\n";
            richTextBox1.Text += processedMessage;
            log.AppendMessage(processedMessage);

            processedMessage = shopKeeper.SelectMessage(textBox1.Text) + "\n";
            richTextBox1.Text += processedMessage;
            log.AppendMessage(processedMessage);
            textBox1.Clear();


        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Rate.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void RateButtonCallback(object sender, System.EventArgs e)
        {
            if (chatting == true)
            {
                richTextBox1.Text += "No puede evaluar si existe una conversacion en curso.\n";
                return;
            }
            rate = 0;

            RateWindow window = new RateWindow();
            var dialogResult = window.ShowDialog();

            InputOutput.SaveRatings(rate);
        }

        /// <summary>
        /// Corresponde a la funcion que cumple el boton Stats.
        /// </summary>
        /// <param name="sender">parametro requerido para el correcto funcionamiento del evento.</param>
        /// <param name="e">parametro requerido para el correcto funcionamiento del evento.</param>
        private void StatsButtonCallback(object sender, System.EventArgs e)
        {
            int[] ratings = InputOutput.GetRatings();

            if (ratings[0] == -1)
            {
                richTextBox1.Text += "No existen evaluaciones que analizar.\n";
                return;
            }

            int timesEvaluated = ratings.Length;
            double average = Utilities.GetAverage(ratings);
            int bestRate = Utilities.Max(ratings);
            int worstRate = Utilities.Min(ratings);

            RatingStatsWindow dialog = new RatingStatsWindow(average, worstRate, bestRate, timesEvaluated);
            var dialogResult = dialog.ShowDialog();
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.53713F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.462867F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.0226F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.9774F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1013, 431);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(930, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(80, 427);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.StartButtonCallback);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(3, 38);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "End";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.EndButtonCallback);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(3, 74);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 32);
            this.button3.TabIndex = 2;
            this.button3.Text = "Save Log";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.SaveButtonCallback);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Location = new System.Drawing.Point(3, 110);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 32);
            this.button4.TabIndex = 3;
            this.button4.Text = "Load Log";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.LoadButtonCallback);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(3, 146);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 32);
            this.button5.TabIndex = 4;
            this.button5.Text = "Rate";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.RateButtonCallback);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Location = new System.Drawing.Point(3, 183);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(76, 32);
            this.button7.TabIndex = 5;
            this.button7.Text = "Stats";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.StatsButtonCallback);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.richTextBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.80952F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.190476F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(921, 427);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.richTextBox1.Location = new System.Drawing.Point(3, 2);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(915, 388);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button6, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 394);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(915, 30);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(3, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(826, 30);
            this.textBox1.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button6.Location = new System.Drawing.Point(835, 2);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 25);
            this.button6.TabIndex = 5;
            this.button6.Text = "Send";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.SendButtonCallback);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 431);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("MingLiU-ExtB", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Chatbot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;

        #endregion
    }
}

