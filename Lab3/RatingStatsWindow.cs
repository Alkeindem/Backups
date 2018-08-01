using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatbot
{
    public partial class RatingStatsWindow : Form
    {
        public RatingStatsWindow(double average, int min, int max, int count)
        {
            InitializeComponent(average, min, max, count);
        }

        private void RatingStatsWindow_Load(object sender, EventArgs e)
        {

        }

        private void RatingStatsWindow_Load_1(object sender, EventArgs e)
        {

        }
    }
}
