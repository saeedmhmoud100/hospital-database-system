using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delet_room2 room2 = new Delet_room2();
            room2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update u = new update();
            u.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectForm selectForm = new selectForm();
            selectForm.Show();
            this.Hide();
        }
    }
}
