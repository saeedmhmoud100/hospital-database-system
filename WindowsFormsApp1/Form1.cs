using DataBase_project;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            try
            {
                if (this.textBox1.Text != "" && this.textBox2.Text != "" && this.comboBox1.SelectedItem.ToString() != "")
                {

                    room.insertRoom(int.Parse(this.textBox1.Text), this.comboBox1.SelectedItem.ToString(), this.textBox2.Text);
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.comboBox1.SelectedIndex = -1;
                string itemToSelect = ""; 
                this.comboBox1.SelectedItem = itemToSelect;
                this.label1.Text = "added successfully";
                this.label1.ForeColor = Color.Green;
                }
                else
                {
                    this.label1.Text = "enter valid data";
                    this.label1.ForeColor = Color.Blue;
                }
            }catch (Exception ex)
            {
                if(this.textBox1.Text == "" || this.textBox2.Text == "" || this.comboBox1.SelectedItem.ToString() == "")
                {
                    this.label1.Text = "";
                }
                else
                {
                    this.label1.Text = "id is already exist";
                    this.label1.ForeColor = Color.Red;
                }
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show(this);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show(this);
            this.Hide();
        }
    }
}
