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

namespace Task2
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            this.AutoScroll = true;

            string filePath = "contacts.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    int yPosition = 49;

                    foreach (string line in lines)
                    {
                        ListBox listBox = new ListBox
                        {
                            Name = "ListBox_" + yPosition,
                            Size = new System.Drawing.Size(309, 56),
                            Location = new System.Drawing.Point(9, yPosition)

                        };

                        listBox.Items.Add(line);

                        this.Controls.Add(listBox);
                        yPosition += 64;
                    }
                }

                else
                {
                    MessageBox.Show("File not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file: {ex.Message}");
            }
        }
    }
}
