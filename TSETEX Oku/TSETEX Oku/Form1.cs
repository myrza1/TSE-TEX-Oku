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

namespace TSETEX_Oku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool Blok;
            string Flight = "";
            string dayOfMonth = "";
            string mvtType = "";
            string aircraftRegistration = "";
            string airport = "";
            try
            {
                using (StreamReader sr = new StreamReader("MVT.txt"))
                {
                    String line;
                    Blok = false;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line == "MVT")
                        {
                            listBox1.Items.Add(line);
                            Blok = true;
                            Flight = "";
                            mvtType = "";
                            dayOfMonth = "";
                            aircraftRegistration = "";
                            airport = "";
                        }
                        else if (line.Length == 0)
                        {
                            Blok = false;
                        }
                        else if (Blok)
                        {
                            if (line.IndexOf("/") != -1 && Flight == "")
                            {
                                Flight = line.Substring(0, line.IndexOf("/"));
                                dayOfMonth = line.Substring(line.IndexOf("/") + 1, 2);
                                aircraftRegistration = line.Substring(line.IndexOf("/") + 4, (line.Length - 4) - (line.IndexOf("/") + 4));
                                airport = line.Substring(line.Length - 3, 3);
                                listBox1.Items.Add("No: " + Flight + " Day: " + dayOfMonth + " REG: " + aircraftRegistration + " Airport: " + airport);
                            }
                            else if (line.StartsWith("AA"))
                            {
                                mvtType = line.Substring(0, line.IndexOf("/"));
                                
                                listBox1.Items.Add(mvtType + " Arrival " + mvtType.Substring(0, 2));

                            }
                            else if (line.StartsWith("AD"))
                            {
                                mvtType = line.Substring(0, line.IndexOf("/"));
                                listBox1.Items.Add(mvtType + " Departure " + mvtType.Substring(0, 2));
                            }


                            //line.Substring(0, line.IndexOf("/"));
                            //listBox1.Items.Add(line + " " + line.IndexOf("/"));
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "Couln not read file";
            }
        }
    }
}
