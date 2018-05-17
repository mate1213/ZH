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

namespace ZH
{
    public partial class Form1 : Form
    {
        public List<Level> level { get; set; }
        public List<Csaomag> csomag { get; set; }
        Random rnd = new Random();
        int newID;

        public Form1()
        {
            InitializeComponent();
            level = new List<Level>();
            csomag = new List<Csaomag>();
            textBox1.Enabled = false;
            checkBox1.Enabled = false;
            textBox6.Enabled = false;
            checkBox2.Enabled = false;
            newID = rnd.Next(10000, 99999);
            if (!IDGen(newID))
            {
                textBox1.Text = newID.ToString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                textBox6.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                textBox6.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                Level tempLevel = new Level();
                if (!IDGen(newID))
                {
                    tempLevel.ID = newID;
                    tempLevel.Cimzett = textBox2.Text;
                    tempLevel.Irszam = textBox3.Text;
                    tempLevel.Varos = textBox4.Text;
                    tempLevel.Cim = textBox5.Text;
                    tempLevel.FeladasDat = DateTime.Now;
                }
                else
                {
                    newID = rnd.Next(10000, 99999);
                    IDGen(newID);
                }
                level.Add(tempLevel);
                listBox1.Items.Add(tempLevel.ToString());
            }

            if (radioButton2.Checked)
            {
                Csaomag tempCsomag = new Csaomag();
                if (!IDGen(newID))
                {
                    tempCsomag.ID = newID;
                    tempCsomag.Cimzett = textBox2.Text;
                    tempCsomag.Irszam = textBox3.Text;
                    tempCsomag.Varos = textBox4.Text;
                    tempCsomag.Cim = textBox5.Text;
                    tempCsomag.FeladasDat = DateTime.Now;
                }
                else
                {
                    newID = rnd.Next(10000, 99999);
                    IDGen(newID);
                }
                double tempDouble;

                if (!double.TryParse(textBox6.Text, out tempDouble))
                    MessageBox.Show("Csak számot lehet megadni!");

                tempCsomag.Tomeg = tempDouble;
                csomag.Add(tempCsomag);
                listBox1.Items.Add(tempCsomag.ToString());
            }

            newID = rnd.Next(10000, 99999);
            if (!IDGen(newID))
            {
                textBox1.Text = newID.ToString();
            }

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox6.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;

        }

        public bool IDGen(int newID)
        {
            bool vanID = false;
            foreach (var item in level)
            {
                if (item.ID == newID)
                {
                    vanID = true;
                }
                else
                    vanID = false;
            }

            if (vanID == false)
            {
                foreach (var item in csomag)
                {
                    if (item.ID == newID)
                        vanID = true;
                    else
                        vanID = false;
                }
            }
            return vanID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> Postak = new Dictionary<string, int>();

            using (StreamReader sr = new StreamReader(@"Posta.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] temp = sr.ReadLine().Split(' ');
                    Postak.Add(temp[0], int.Parse(temp[1]));
                }
            }
            using (StreamWriter sw = new StreamWriter("eredmeny.txt"))
            {
                foreach (var item in level)
                {
                    if (Postak.Keys.Contains<string>(item.Varos))
                    {
                        sw.WriteLine(item.ToString() + " [" + Postak.Values.)
                    }
                }
            }

        }
    }
}
