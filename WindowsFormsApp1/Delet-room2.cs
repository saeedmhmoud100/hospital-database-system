using DataBase_project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Delet_room2 : Form
    {
        public Delet_room2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            
            room.DeleteRoom(int.Parse(this.textBox2.Text));

            this.button1.Visible = false;
            this.textBox2.Text = string.Empty;
            this.label1.Text = "Deleted successfully";
            this.label1.ForeColor = Color.Green;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Select s = new Select();
                List<string> list = s.ApplySelect("ROOM",null,null,int.Parse(this.textBox2.Text));

                if(list.Count > 0 && this.textBox2.Text != "")
                {
                    this.button1.Visible = true;
                    this.label1.Text = "";
                }
                else
                {
                    this.button1.Visible = false;
                    this.label1.Text = "Wrong id";
                    this.label1.ForeColor = Color.Red;
                }
                
            }catch (Exception ex)
            {

            this.button1.Visible = false;
            if (this.textBox2.Text != "")
            {

                this.label1.Text = "Wrong id";
                this.label1.ForeColor = Color.Red;
                }
                else
                {
                this.label1.Text = "";

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }
    }
}
