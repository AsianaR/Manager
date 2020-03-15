using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Control : Form
    {
        string RadioVal, link;
        int counter = 0;
        int outcount = 0;

        private Image img;


        public Control()
        {
            
            InitializeComponent();

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                RadioVal = radioButton.Text;
            }
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Не указано имя!");
            }
            else if (textBox1.Text.Length < 3)
            {
                errorProvider1.SetError(textBox1, "Слишком короткое имя!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Не указано имя!");
            }
            else if (textBox2.Text.Length < 3)
            {
                errorProvider1.SetError(textBox2, "Слишком короткое имя!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Control cnt = new Control();
            cnt.Show();
            counter++;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            /*if (outcount == 0)
            {
                string lines = textBox1.Text + " " + textBox2.Text + " " + RadioVal + "\n";

                System.IO.File.WriteAllText(@"C:\Users\user\source\repos\WindowsFormsApp2\bin\Debug\Source.txt", lines);
            }
            else
            {*/
            var text = textBox1.Text + " " + textBox2.Text + " " + RadioVal + " " + link;
                using (var writer = new StreamWriter("Source.txt", true))
                {
                    writer.WriteLine(text);
                }
            
         //   outcount++;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

            if (radioButton.Checked)
            {
                RadioVal = radioButton.Text;
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string s = File.ReadAllLines("").Last();
            string lines = File.ReadAllLines("Source.txt").Last();
            //string NonSplited = lines[counter];
           

            string[] words = lines.Split(new char[] { ' ' });


            if (words[0] != null && words[1] != null && words[2] != null)
            {
   
                textBox1.Text = words[0];
                textBox2.Text = words[1];



                if (words[2] == "Enduro")
                    radioButton1.Checked = true;
                else if (words[2] == "DH")
                    radioButton2.Checked = true;
                else if (words[2] == "XC")
                    radioButton3.Checked = true;
                else
                    MessageBox.Show("Error");
            }

            else
                MessageBox.Show("Error");

            if(words[3] != null)
            {
                link = words[3];
            }
           // string link = "C:/Users/user/source/repos/WindowsFormsApp2/bin/Debug/Images/1.jpg";
            pictureBox1.Image = Image.FromFile(link);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                RadioVal = radioButton.Text;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
          
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
         
            MessageBox.Show("Выбран файл: " + openFileDialog1.FileName);
            link = openFileDialog1.FileName;
        }


    }


    
}
