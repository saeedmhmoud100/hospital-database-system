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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();

        }

        private void update_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


            Select s = new Select();
            try
            {

                List<string> list = s.ApplySelect("ROOM",null,null,int.Parse(this.textBox1.Text));
                foreach(var i in list)
                {
                    Debug.WriteLine(i);
                }
                this.comboBox1.Text = list[1];
                this.textBox2.Text = list[2];

                this.textBox2.Visible = true;
                this.comboBox1.Visible = true;
                this.label3.Visible = true;
                this.label5.Visible = true;
                this.button1.Visible = true;
                this.label4.Text = "";
            }catch(Exception ex)
            {
                this.textBox2.Visible = false;
                this.comboBox1.Visible = false;
                this.label3.Visible = false;
                this.label5.Visible = false;
                this.button1.Visible = false;
                if(this.textBox1.Text == "")
                {

                this.label4.Text = "";
                }
                else
                {
                this.label4.Text = "wrong id";
                this.label4.ForeColor = Color.Red;

                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Room room = new Room();
                room.updateRoom(int.Parse(this.textBox1.Text), this.comboBox1.SelectedText, this.textBox2.Text);
                this.label4.Text = "Updated Successfully";
                this.label4.ForeColor = Color.Green;
            }
            catch(Exception ex)
            {
                this.label4.Text = "there is an error";
                this.label4.ForeColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Hide();
        }
    }
}
