using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design.Forms
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();           
        }
        private void Customer_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        void LoadTheme()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    Button button2 = (Button)item;
                    button2.BackColor = ThemeColor.PrimaryColor;
                    button2.ForeColor = Color.White;
                    button2.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
                if (item is Label)
                {
                    Label label2 = (Label)item;
                    label2.ForeColor = ThemeColor.SecondaryColor;
                }
            }
        }
    }
}
