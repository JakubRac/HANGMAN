using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace suicide_game
{
    public partial class Form1 : Form
    {
        static int index = 0;
        string temp_pass;
        char c;
        Calculate calculate;
        string[] passwords;
        string password;
        string hashPass;
        public static StringBuilder hashPass_builder;
        
        public Form1()
        {
            InitializeComponent();
            passwords = File.ReadAllLines("text.txt");
            password = RandPass(passwords);
            this.button2.Visible = false;
            //calculate = new Calculate(password);
            //hashPass = calculate.HashPass();
            //hashPass_builder = new StringBuilder(hashPass);
            //this.label.Text = hashPass_builder.ToString();
            //this.button1.Visible = false;
            Reset();

            

            
        }

        private string RandPass(string[] passwords)
        {
            Random rand = new Random();
            int i = rand.Next(0, passwords.Length);
            return passwords[i];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ItIs = true;
            this.temp_pass = this.textBox1.Text;
            if (temp_pass.Length > 0)
            {
               
                this.c = temp_pass.ElementAt(0);
                if (calculate.CheckChar(c, hashPass_builder, label))
                {
               
                    foreach (char temp in hashPass_builder.ToString())
                    {
                        if (temp == '*')
                        {
                            ItIs = false;
                            break;
                        }
                           
                    }
                    if (ItIs)
                    {
                        Win();
                    }
                }
                else
                {
                    index++;
                    this.pictureBox1.Load("img_sss\\s" + index + ".jpg");
                    if (index == 9)
                    {
                        Lose();
                    }
                    //
                }
                Thread.Sleep(500);
                this.textBox1.Clear();
            }

        }

        public void Lose()
        {
            this.label3.Text = "Przegrana";
            this.button1.Enabled = false;
            this.label.Enabled = false;
            this.textBox1.Enabled = false;
            this.button2.Visible = true;
        }

        public void Win()
        {
            this.label3.Text = "Wygrana";
            this.button1.Enabled = false;
            this.textBox1.Enabled = false;
            this.button2.Visible = true;

        }

        public void Reset()
        {
            password = RandPass(passwords);
            calculate = new Calculate(password);
            hashPass = calculate.HashPass();
            hashPass_builder = new StringBuilder(hashPass);
            this.label.Text = hashPass_builder.ToString();
            this.button1.Visible = false;
            this.label3.Text = "";
            this.textBox1.Enabled = true;
            this.pictureBox1.Load("img_sss\\s" +0+ ".jpg");
            index = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
            this.button2.Visible = false;
        }
    }
}
