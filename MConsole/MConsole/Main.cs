using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MConsole
{
    public partial class Main : Form
    {
        // MConsole V1
        // IF YOU MAKE MODIFICATIONS PLEASE CREDIT MITKO NIKOV
        // AND I WANT TO SEE YOUR MODIFICATIONS AND MAYBE WE WILL HAVE NEW VERSION
        // SEND ME THOSE TO MY EMAIL : mitkonikov01@gmail.com

        // Current Line
        int Line = 0;

        public Main()
        {
            InitializeComponent();
            Dec1(); //Decoration Method
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) // if Enter is pressed
            {
                // exec the command
                try
                {
                    if (textBox1.Lines[Line] == "" & Line == 0)
                    {
                        Console.WriteLine("Empty Line!"); // Just for signalling
                    }
                    else
                    {
                        // Line = 0 (for the first time)
                        if (textBox1.Lines[Line].ToLower() == "help")
                        {
                            // Exec the help command
                            // Add a text into the textbox1
                            textBox1.Text += Environment.NewLine + "CLOSE -- Closing the app!";
                            textBox1.Text += Environment.NewLine + "DIR -- Directory options";
                            LineLOC(3); // Add lines for the text outputed + Add a line for the next user input
                            // ---- Set the cursor at the last letter ----
                            textBox1.SelectionStart = textBox1.Text.Length;
                            textBox1.SelectionLength = 0;
                            // -------------------------------------------
                        }
                        else if (textBox1.Lines[Line].ToLower() == "dir")
                        {
                            // Exec the help command
                            // Add a text into the textbox1
                            textBox1.Text += Environment.NewLine + "DIR [current] - Gets the current directory";
                            LineLOC(2); // Add lines for the text outputed + Add a line for the next user input
                            // ---- Set the cursor at the last letter ----
                            textBox1.SelectionStart = textBox1.Text.Length;
                            textBox1.SelectionLength = 0;
                            // -------------------------------------------
                        }
                        else if (textBox1.Lines[Line].ToLower() == "dir current")
                        {
                            // Exec the help command
                            // Add a text into the textbox1
                            textBox1.Text += Environment.NewLine + System.IO.Directory.GetCurrentDirectory();
                            LineLOC(2); // Add lines for the text outputed + Add a line for the next user input
                            // ---- Set the cursor at the last letter ----
                            textBox1.SelectionStart = textBox1.Text.Length;
                            textBox1.SelectionLength = 0;
                            // -------------------------------------------
                        }
                        else if (textBox1.Lines[Line].ToLower() == "close")
                        {
                            //Exec the close command
                            Close();
                        }
                        else
                        {
                            // here another command
                            // WARNING: You must call LineLOC method in the last function (ex. close) in the else brackets
                            LineLOC(1);
                        }
                    }
                }
                catch
                {
                    // There will be error if you dont fill the first command line with any text
                    // So I put here a "catch"
                    LineLOC(1);
                }
            }
        }

        private void LineLOC(int times) // Line Location Method
        {
            for (int i = 0; i < times; i++)
            {
                Line++;
                if (Line < 17)
                {
                    // Sets up the location of the prompt (">")
                    // You can change the label1 Text when you are in different folders
                    label1.Location = new Point(label1.Location.X, label1.Location.Y + 16);
                }
            }
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            // THERE IS SOME TIME DELAY IN WHICH YOU CAN TRY TO CHANGE SOMETHING
            // IF YOU KNOW HOW TO FIX IT OR YOU HAVE ALTERNATIVE WAY OF PREVENTING
            // YOU SHOULD WRITE TO MY EMAIL : mitkonikov01@gmail.com
            textBox1.Enabled = false; // To prevent changing the words
            // ---- Set the cursor at the last letter ----
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            // -------------------------------------------
            label1.Text = ""; //It hides the label text (instead of label1.Hide();)
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();
            label1.Text = ">"; //It revivals the label text again
            // ---- Set the cursor at the last letter ----
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            // -------------------------------------------
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) //Keys.Up is the Upper Arrow
            {
                UpTimer1.Start();
            }
        }

        private void UpTimer1_Tick(object sender, EventArgs e)
        {
            // THERE MUST BE SOME DELAY BECAUSE IT WILL RUN THE "SET UP CURSOR"
            // FIRST BEFORE THE UPPER KEY IS REGISTERED IN THE TEXTBOX
            // ---- Set the cursor at the last letter ----
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.SelectionLength = 0;
            // -------------------------------------------
            UpTimer1.Stop();
        }

        private void Dec1()
        {
            // JUST FOR DECORATION
            Bitmap b1;
            Graphics g1;
            b1 = new Bitmap(102, 102);
            g1 = Graphics.FromImage(b1);
            g1.DrawEllipse(new Pen(Color.FromArgb(107, 173, 246), 2f), 0, 0, 100, 100);//-------------------
            g1.DrawEllipse(new Pen(Color.FromArgb(107, 173, 246), 3f), 20, 20, 60, 60);//Draws some eclipses
            g1.DrawEllipse(new Pen(Color.FromArgb(107, 173, 246), 4f), 40, 40, 20, 20);//-------------------
            pictureBox1.Image = b1;
            g1.Dispose();
        }

    }
}
